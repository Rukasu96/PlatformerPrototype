using UnityEngine;

public abstract class EntitySpawnManager : MonoBehaviour
{
    [SerializeField] protected SpawnPointStrategyType spawnPointStrategyType = SpawnPointStrategyType.Specific;
    protected Transform spawnPoint;
    protected ISpawnPointStrategy spawnPointStrategy;

    //Later in process check if this is still need
    protected enum SpawnPointStrategyType
    {
        Specific,
    }

    protected void SetStrategyType()
    {
        switch (spawnPointStrategyType)
        {
            case SpawnPointStrategyType.Specific:
                spawnPointStrategy = new SpecificSpawnPointStrategy(spawnPoint);
                break;
        }
    }

    public abstract void Spawn();
}
