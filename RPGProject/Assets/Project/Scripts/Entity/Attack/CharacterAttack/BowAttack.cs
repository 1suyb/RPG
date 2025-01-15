using System;
using Manager;
using UnityEngine;

public class BowAttack : CharacterAttack
{
    public override void Attack()
    {   
        Transform attackPivot = _characterPivot.AttackPivot; 
        AttackHandler attackHandler = new AttackHandler( _currentStat, _attackData);
        ProjectileController.Instance.CreateProjectile(1,_character.Target, _targetLayer, attackHandler, attackPivot.position, attackPivot.rotation);
    }
}
