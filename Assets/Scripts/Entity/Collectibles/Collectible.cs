using DG.Tweening;
using UnityEngine;

public class Collectible : Entity
{
    [SerializeField] float collectAnimationOnY;
    [SerializeField] float jumpDuration;
    [SerializeField] float scaleAnimation;
    [SerializeField] float scaleDuration;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        Collected();
    }

    protected void Collected()
    {
        transform.DOMoveY(collectAnimationOnY, jumpDuration).OnComplete(() =>
        {
            transform.DOScale(scaleAnimation, scaleDuration).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        });
    }
}
