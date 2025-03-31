using System;

public abstract class Timer
{
    protected float initialTime;
    protected float time;
    public bool IsRunning {  get; protected set; }

    public float Progress => time / initialTime;

    public Action OnTimerStart = delegate { };
    public Action OnTimerStop = delegate { };

    protected Timer(float init)
    {
        initialTime = init;
        IsRunning = false;
    }

    public void StartTimer()
    {
        time = initialTime;
        if(!IsRunning)
        {
            IsRunning = true;
            OnTimerStart.Invoke();
        }
    }

    public void StopTimer()
    {
        if(IsRunning)
        {
            IsRunning = false;
            OnTimerStop.Invoke();
        }
    }

    public void ResumeTimer() => IsRunning = true;
    public void PauseTimer() => IsRunning = false;

    public abstract void Tick(float deltaTime);
}
