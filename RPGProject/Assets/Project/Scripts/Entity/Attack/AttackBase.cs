using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    protected LayerMask _targetLayer;
    public void DealDamage(Collider target, LayerMask targetLayer, AttackHandler attackHandler, Transform attacker)
    {
        IDamageable damageable = target.gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(attackHandler);
        }
    }
    
}

public abstract class AttackCommand : ICommand
{
    protected AttackHandler _attackHandler;
    protected Transform _attacker;
    protected Collider _target;
    protected LayerMask _targetLayer;
    public AttackCommand(AttackHandler attackHandler, Transform attacker, Collider target, LayerMask targetLayer)
    {
        _attackHandler = attackHandler;
        _attacker = attacker;
        _target = target;
        _targetLayer = targetLayer;
    }
    public abstract void Execute();
}