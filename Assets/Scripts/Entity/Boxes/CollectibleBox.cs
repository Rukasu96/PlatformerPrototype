using System;
using UnityEngine;

public class CollectibleBox : Box
{
    [SerializeField] CollectibleBoxData collectibleBoxdata;
    
    public static event Action<CollectibleData, Transform, int> OnCollectibleBoxDestroyed;

    protected override void BoxDestroy()
    {
        OnCollectibleBoxDestroyed?.Invoke(collectibleBoxdata.collectibleData , transform, 5);
        Destroy(gameObject);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        BoxDestroy();
    }
}
