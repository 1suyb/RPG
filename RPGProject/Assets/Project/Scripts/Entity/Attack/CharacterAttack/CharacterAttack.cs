using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAttack : AttackBase
{
    protected Character _character;
    protected EntityPivot _characterPivot;
    protected AttackData _attackData => _character.CurrentAttackData;
    protected Stat _currentStat => _character.StatHandler.CurrentStat;
    protected new LayerMask _targetLayer => _character.TargetLayer;
    
    protected void Start()
    {
        _character = GetComponentInParent<Character>();
        _characterPivot = GetComponent<EntityPivot>();
    }

    public abstract void Attack();
}
