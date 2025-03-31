using DG.Tweening;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] float animationScaleDuration = 1f;
    [SerializeField] float animationJumpDuration = 1f;
    [SerializeField] float jumpHeight;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, animationScaleDuration).SetEase(Ease.OutBack);
        transform.DOMoveY(transform.position.y + jumpHeight, animationJumpDuration).SetEase(Ease.InSine).SetLoops(2,LoopType.Yoyo);
    }
}
