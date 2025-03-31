using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawnPointStrategy : ISpawnPointStrategy
{
    Transform spawnPoint;

    public RandomSpawnPointStrategy(Transform spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }

    public Transform SpawnPoint()
    {
        return spawnPoint;
    }
}
