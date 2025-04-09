using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleBoxData", menuName = "Platformer/Box data")]

public class CollectibleBoxData : EntityData
{
    public CollectibleData collectibleData;
    public int minCollectibleContain;
    public int maxCollectibleContain;
    
}
