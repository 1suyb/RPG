using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    protected AttackData _attackData;
    public void SetAttackData(AttackData attackData)
    {
        _attackData = attackData;
    }
    public abstract void Attack();
    
}
