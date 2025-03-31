using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleBoxData", menuName = "Platformer/Box data")]

public class CollectibleBoxData : EntityData
{
    public GameObject collectibleInsidePrefab;
    public int minCollectibleContain;
    public int maxCollectibleContain;
    
}
