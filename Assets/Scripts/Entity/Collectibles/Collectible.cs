using DG.Tweening;
using UnityEngine;

public class Collectible : Entity
{

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || !GetComponent<SpawnEffect>().isFinished)
        {
            return;
        }

        Collected();
    }

    protected void Collected()
    {
        CollectibleManager.OnCollected?.Invoke(this);
    }
}
