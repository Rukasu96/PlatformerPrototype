using UnityEngine;

public class CollectiblesSpawnManager : EntitySpawnManager
{
    EntitySpawner<Collectible> spawner;

    public override void Spawn()
    {
        spawner.Spawn();
    }

    public void SetToSpawn(CollectibleData collectibleData, Transform spawnPoint, int amount)
    {
        this.spawnPoint = spawnPoint;
        SetStrategyType();
        spawner = new EntitySpawner<Collectible>(new EntityFactory<Collectible>(collectibleData), spawnPointStrategy);
        
        for (int i = 0; i < amount; i++)
        {
            Spawn();
        }
    }
}
