using System;
using UnityEngine;

public abstract class Box : Entity
{
    protected abstract void OnTriggerStay(Collider other);

    protected abstract void OnTriggerEnter(Collider other);

    protected abstract void BoxDestroy();
}
