using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    [SerializeField] float collectAnimationOnY;
    [SerializeField] float jumpDuration;
    [SerializeField] float scaleAnimation;
    [SerializeField] float scaleDuration;

    public async UniTask PlayCollectEffect()
    {
        await transform.DOMoveY(collectAnimationOnY, jumpDuration);
        await transform.DOScale(scaleAnimation, scaleDuration);
    }
}
