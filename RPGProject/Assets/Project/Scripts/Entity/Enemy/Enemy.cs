using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, ILoadable
{
    [field:SerializeField] public StatHandler StatHandler { get; private set; }
    [field:SerializeField] public EnemyConditionHandler ConditionHandler { get; private set; }
    
    [field:SerializeField] public AttackData CurrentAttackData { get; private set; }
    [field:SerializeField] public LayerMask TargetLayer { get; private set; }
    [field:SerializeField] public Transform Target { get; private set; }
    public Stat CurrentStat => StatHandler.CurrentStat;
    
    public void Load(int id)
    {
        
    }

    public void Awake()
    {
        if(StatHandler == null)
            StatHandler = GetComponent<StatHandler>();
        if(ConditionHandler == null)
            ConditionHandler = GetComponent<EnemyConditionHandler>();
    }

    public void Start()
    {
        ConditionHandler.InitOnCreate(StatHandler);
    }

    public void TakeDamage(AttackHandler attackHandler)
    {
        Debug.Log($"나맞앗어 {attackHandler.CalculateDamage(CurrentStat)}");
        
    }


}
