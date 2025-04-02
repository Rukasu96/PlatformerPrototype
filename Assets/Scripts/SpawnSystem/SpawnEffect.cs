using DG.Tweening;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] float animationScaleDuration = 1f;
    [SerializeField] float animationJumpDuration = 1f;
    [SerializeField] float animationSpreadDuration = 1f;
    [SerializeField] float jumpHeight;
    [SerializeField] float maxSpread;

    private void Start()
    {
        Vector3 random = SpreadRandomizer.RandomSpreadPosition(maxSpread, transform);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, animationScaleDuration).SetEase(Ease.OutBack);
        transform.DOMoveY(transform.position.y + jumpHeight, animationJumpDuration).SetEase(Ease.InSine).OnComplete(() =>
        {
            transform.DOMove(random, animationSpreadDuration);
        });
    }
}
