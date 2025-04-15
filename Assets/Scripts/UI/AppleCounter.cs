using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class AppleCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    private int value;

    StopwatchTimer timer;

    public static Action OnCounterIncreased;

    private void Awake()
    {
        timer = new StopwatchTimer();
    }

    private async void IncreaseCounter()
    {
        transform.DOLocalMoveY(467f, 0.5f).SetEase(Ease.InSine);
        value++;
        counterText.text = value.ToString();
        await HideCounter();
    }
    
    private async UniTask HideCounter()
    {
        await UniTask.WaitForSeconds(2);
        await transform.DOLocalMoveY(613f, 0.5f).SetEase(Ease.InSine);
    }

    private void OnEnable()
    {
        OnCounterIncreased += IncreaseCounter;
    }

    private void OnDestroy()
    {
        OnCounterIncreased -= IncreaseCounter;
    }
}
