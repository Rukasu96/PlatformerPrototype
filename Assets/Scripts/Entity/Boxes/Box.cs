using UnityEngine;

public abstract class Box : Entity
{
    protected abstract void OnTriggerEnter(Collider other);

    protected abstract void BoxDestroy();
}
