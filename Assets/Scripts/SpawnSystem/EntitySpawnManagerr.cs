using UnityEngine;

public abstract class EntitySpawnManager : MonoBehaviour
{
    [SerializeField] protected SpawnPointStrategyType spawnPointStrategyType = SpawnPointStrategyType.Random;
    [SerializeField] protected Transform[] spawnPoints;

    protected ISpawnPointStrategy spawnPointStrategy;

    protected enum SpawnPointStrategyType
    {
        Random,
    }

    protected virtual void Awake()
    {
        switch (spawnPointStrategyType)
        {
            case SpawnPointStrategyType.Random:
                spawnPointStrategy = new RandomSpawnPointStrategy(spawnPoints);
                break;
        }
    }

    public abstract void Spawn();
}
