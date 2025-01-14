using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    protected AttackData _attackData;
    protected LayerMask _targetLayer;
    public void DealDamage(Collider target, LayerMask targetLayer, AttackData attackData, Transform attacker)
    {
        IDamageable damageable = target.gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_attackData.PhysicalPlat);
        }
    }
}
