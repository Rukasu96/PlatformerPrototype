using UnityEngine;

public class CollectiblesSpawnManager : EntitySpawnManager
{
    [SerializeField] CollectibleData[] collectibleData;

    EntitySpawner<Collectible> spawner;

    protected override void Awake()
    {
        base.Awake();
        spawner = new EntitySpawner<Collectible>(new EntityFactory<Collectible>(collectibleData), spawnPointStrategy);
    }

    public override void Spawn()
    {
        spawner.Spawn();
    }
}
