using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    public List<Collider> Colliders { get; private set; }
    private LayerMask _targetLayer;
    public event Action<Collider> OnHit;

    private void OnTriggerEnter(Collider other)
    {
        if (Colliders.Contains(other))
        {
            return;
        }

        if (1<<other.gameObject.layer == _targetLayer)
        {
            Colliders.Add(other);
            OnHit?.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Colliders.Contains(other))
        {
            Colliders.Remove(other);
        }
    }

    public void InitOnActivate(LayerMask targetLayer)
    {
        Colliders = new List<Collider>();
        _targetLayer = targetLayer;
    }

    public void OnDisable()
    {
        Colliders.Clear();
    }
}
