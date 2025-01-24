using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable, IHealable
{
    [field : Header("Target")]
    [field : SerializeField] public LayerMask TargetLayer { get; private set; }
    [field : SerializeField] public Transform Target { get; private set; }
    
    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public virtual event Action OnDie;
    public abstract void TakeDamage(AttackHandler attackHandler);
    public abstract void ReceiveHealing();
}
