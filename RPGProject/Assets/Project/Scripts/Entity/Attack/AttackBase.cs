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