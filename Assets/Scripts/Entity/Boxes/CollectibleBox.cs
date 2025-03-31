using UnityEngine;

public class CollectibleBox : Box
{
    [SerializeField] CollectibleBoxData collectibleBoxdata;


    protected override void BoxDestroy()
    {
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
