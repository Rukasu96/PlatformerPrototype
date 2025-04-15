using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] InputReader input;
    [SerializeField] CinemachineCamera freeLookVCam;
    [SerializeField] Animator animator;
    [Header("Move Settings")]
    [SerializeField] float Acceleration;
    [SerializeField] float Deceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float rotationTime;

    [Header("Jump Settings")]
    [SerializeField] float jumpForce;
    [SerializeField] float jumpDuration;
    [SerializeField] float jumpCooldown;
    [SerializeField] float jumpMaxHeight;
    [SerializeField] float gravityMultiplier;

    [Header("Attack Settings")]
    [SerializeField] float attackDuration;
    [SerializeField] float attackCooldown;

    private GroundChecker groundChecker;
    private Rigidbody rb;
    private Vector3 moveDirection;
    float turnSmoothVelocity;
    float jumpVelocity;
    float currentSpeed;
    Transform mainCam;

    static readonly int Speed = Animator.StringToHash("Speed");
    public bool isAttack;

    List<Timer> timers;
    CountdownTimer jumpTimer;
    CountdownTimer jumpCooldownTimer;
    CountdownTimer attackTimer;
    CountdownTimer attackCooldownTimer;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        mainCam = Camera.main.transform;
        freeLookVCam.Follow = transform;
        freeLookVCam.LookAt = transform;
        freeLookVCam.OnTargetObjectWarped(transform, transform.position - freeLookVCam.transform.position - Vector3.forward);

        jumpTimer = new CountdownTimer(jumpDuration);
        jumpCooldownTimer = new CountdownTimer(jumpCooldown);
        jumpTimer.OnTimerStart += () => jumpCooldownTimer.StartTimer();

        attackTimer = new CountdownTimer(attackDuration);
        attackCooldownTimer = new CountdownTimer(attackCooldown);
        attackTimer.OnTimerStart += () => attackCooldownTimer.StartTimer();

        timers = new List<Timer>(4) { jumpTimer, jumpCooldownTimer, attackTimer, attackCooldownTimer };

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        moveDirection = new Vector3(input.Direction.x, 0f, input.Direction.y);
        HandleTimers();
        UpdateRunningAnimator();
        HandleAttack();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        Vector3 moveVector = new Vector3(moveDirection.x, 0f, moveDirection.z);
        Vector3 adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * moveVector;
        rb.AddForce(adjustedDirection * Acceleration, ForceMode.Force);
        currentSpeed = adjustedDirection.magnitude;
        if (adjustedDirection.magnitude > 0.1f)
        {
            RotatePlayer(adjustedDirection);
            if(rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }

        if (adjustedDirection == Vector3.zero)
        {
            rb.AddForce(rb.linearVelocity * -Deceleration, ForceMode.Force);
        }
        
    }

    private void UpdateRunningAnimator()
    {
        animator.SetFloat(Speed, currentSpeed);
    }

    private void RotatePlayer(Vector3 adjustedDirection)
    {
        float targetAngle = Mathf.Atan2(adjustedDirection.x, adjustedDirection.z) * Mathf.Rad2Deg;
        float diff = Quaternion.Angle(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + targetAngle, transform.rotation.z));
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, (int)diff <= 90 ? rotationTime : 0.01f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    private void OnAttack(bool isPressed)
    {
        if (isPressed && !attackTimer.IsRunning && !attackCooldownTimer.IsRunning)
        {
            attackTimer.StartTimer();
        }
        else if (!isPressed && jumpTimer.IsRunning)
        {
            attackTimer.StopTimer();
        }
    }

    private void HandleAttack()
    {
        if(!attackTimer.IsRunning)
        {
            attackTimer.StopTimer();
            //animator.SetBool("Attack", false);
            isAttack = false;
            return;
        }

        if (attackTimer.IsRunning)
        {
            //animator.SetBool("Attack", true);
            isAttack = true;
        }
    }

    private void OnJump(bool isPressed)
    {
        if(isPressed && !jumpTimer.IsRunning && !jumpCooldownTimer.IsRunning && groundChecker.IsGrounded)
        {
            jumpTimer.StartTimer();
        }else if(!isPressed && jumpTimer.IsRunning)
        {
            jumpTimer.StopTimer();
        }
    }

    private void HandleJump()
    {
        if(!jumpTimer.IsRunning && groundChecker.IsGrounded)
        {
            jumpVelocity = 0f;
            jumpTimer.StopTimer();
            animator.SetBool("Jump", false);
            return;
        }

        if(jumpTimer.IsRunning)
        {
            animator.SetBool("Jump", true);
            float launchPoint = 0.9f;
            if(jumpTimer.Progress > launchPoint)
            {
                jumpVelocity = Mathf.Sqrt(2 * jumpMaxHeight * Mathf.Abs(Physics.gravity.y));
            }else
            {
                jumpVelocity += (1 - jumpTimer.Progress) * jumpForce * Time.fixedDeltaTime;
            }
        }else
        {
            jumpVelocity += Physics.gravity.y * gravityMultiplier * Time.fixedDeltaTime;
        }

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpVelocity, rb.linearVelocity.z);
    }

    private void HandleTimers()
    {
        foreach(var timer in timers)
        {
            timer.Tick(Time.deltaTime);
        }
    }

    public void Bounce()
    {
        if (!jumpTimer.IsRunning && !jumpCooldownTimer.IsRunning)
        {
            jumpTimer.StartTimer();
            HandleJump();
        }
        else if (groundChecker.IsGrounded && jumpTimer.IsRunning)
        {
            jumpTimer.StopTimer();
        }
    }

    private void OnEnable()
    {
        input.Jump += OnJump;
        input.Attack += OnAttack;
    }

    private void OnDisable()
    {
        input.Jump -= OnJump;
        input.Attack -= OnAttack;
    }
}