using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, ILoadable
{
    [field:SerializeField] public CharacterStatHandler StatHandler { get; private set; }
    [field:SerializeField] public EnemyConditionHandler ConditionHandler { get; private set; }
    [field:SerializeField] public AttackData CurrentAttackData { get; private set; }
    [field:SerializeField] public LayerMask TargetLayer { get; private set; }
    [field:SerializeField] public Transform Target { get; private set; }
    
    public void Load(int id)
    {
        
    }
    
    public void Start()
    {
        ConditionHandler.InitOnCreate();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"나맞앗어 {damage}");
    }


}
