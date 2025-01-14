using System;
using Manager;
using UnityEngine;

public class BowAttack : CharacterAttack
{
    public override void Attack()
    {   
        Transform attackPivot = _characterPivot.AttackPivot;
        ProjectileController.Instance.CreateProjectile(1,_character.Target, _targetLayer, _attackData,attackPivot.position, attackPivot.rotation);
    }
}
