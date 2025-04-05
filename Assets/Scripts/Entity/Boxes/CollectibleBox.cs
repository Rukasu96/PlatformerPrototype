using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleBox : Box
{
    [SerializeField] CollectibleBoxData collectibleBoxdata;
    [SerializeField] Transform topHitPoint;
    
    public static event Action<CollectibleData, Transform, int> OnCollectibleBoxDestroyed;

    protected override void BoxDestroy()
    {
        OnCollectibleBoxDestroyed?.Invoke(collectibleBoxdata.collectibleData , transform, 5);
        Destroy(gameObject);
    }

    protected override void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Movement>().isAttack)
        {
            return;
        }
        BoxDestroy();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        Vector3 distance = other.gameObject.transform.position - topHitPoint.transform.position;
        float distanceY = Mathf.Abs(distance.y);

        if(distanceY < 0.7)
        {
            return;
        }
        other.GetComponent<Movement>().Bounce();
        BoxDestroy();
    }
}
