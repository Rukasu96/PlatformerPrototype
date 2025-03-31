using UnityEngine;

public abstract class EntitySpawnManager : MonoBehaviour
{
    [SerializeField] protected SpawnPointStrategyType spawnPointStrategyType = SpawnPointStrategyType.Random;
    protected Transform spawnPoint;
    protected ISpawnPointStrategy spawnPointStrategy;

    protected enum SpawnPointStrategyType
    {
        Random,
    }

    protected void SetStrategyType()
    {
        switch (spawnPointStrategyType)
        {
            case SpawnPointStrategyType.Random:
                spawnPointStrategy = new RandomSpawnPointStrategy(spawnPoint);
                break;
        }
    }

    public abstract void Spawn();
}
