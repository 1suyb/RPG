using System;
using Manager;
using UnityEngine;

public class BowAttack : MonoBehaviour
{
    private Character _character;
    private AttackData _attackData => _character.CurrentAttackData;
    
    private void Start()
    {
        _character = GetComponentInParent<Character>();
    }

    public void Attack()
    {
        ProjectileController.Instance.CreateProjectile(1,this.transform.position,this.transform.rotation,_character.Target, _attackData);
    }
}
