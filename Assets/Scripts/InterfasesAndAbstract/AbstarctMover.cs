using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstarctMover : MonoBehaviour
{
    [SerializeField] protected EntityState entityState;

    protected virtual void Moving(Vector3 direction)
    {
    }
}
