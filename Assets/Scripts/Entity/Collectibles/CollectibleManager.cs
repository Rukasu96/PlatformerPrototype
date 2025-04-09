using System;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{

    public static Action<Collectible> OnCollected;

    private async void Collect(Collectible collectible)
    {
        AppleCounter.OnCounterIncreased?.Invoke();
        await collectible.GetComponent<CollectEffect>().PlayCollectEffect();
        Destroy(collectible.gameObject);
    }

    private void OnEnable()
    {
        OnCollected += Collect;
    }

    private void OnDestroy()
    {
        OnCollected -= Collect;
    }
}
