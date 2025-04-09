using UnityEngine;

public class SpecificSpawnPointStrategy : ISpawnPointStrategy
{
    Transform spawnPoint;

    public SpecificSpawnPointStrategy(Transform spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }
}
