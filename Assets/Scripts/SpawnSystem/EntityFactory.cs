using UnityEngine;

public class EntityFactory<T> : IEntityFactory<T> where T : Entity 
{
    EntityData data;

    public EntityFactory(EntityData data)
    {
        this.data = data;
    }

    public T Create(Transform spawnPoint)
    {
        GameObject instance = GameObject.Instantiate(data.prefab, spawnPoint.position, spawnPoint.rotation);
        return instance.GetComponent<T>();
    }
}
