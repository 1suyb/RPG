using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, ILoadable
{
    [field:SerializeField] public StatHandler StatHandler { get; private set; }
    [field:SerializeField] public EnemyConditionHandler ConditionHandler { get; private set; }
    [field:SerializeField] public EnemyController Controller { get; private set; }
    [field:SerializeField] public AttackData CurrentAttackData { get; private set; }
    [field:SerializeField] public LayerMask TargetLayer { get; private set; }
    [field:SerializeField] public Transform Target { get; private set; }
    public Stat CurrentStat => StatHandler.CurrentStat;
    public event Action OnDie;
    public event Action OnHit;
    public event Action<float> OnHpChange;
    public event Action<float> OnShieldChange;
    
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
        ConditionHandler.AddDieEvent(()=>{OnDie?.Invoke();});
        ConditionHandler.AddHpChangeEvent((hp)=>{OnHpChange?.Invoke(hp);});
        ConditionHandler.AddShieldChangeEvent((shield)=>{OnShieldChange?.Invoke(shield);});
        ConditionHandler.AddTakeDamageEvent(()=>{OnHit?.Invoke();});
        OnDie += Die;
    }

    public void Die()
    {
        Controller.Dead();
    }

    public void TakeDamage(AttackHandler attackHandler)
    {
        int damage = attackHandler.CalculateDamage(CurrentStat);
        Debug.Log($"나맞앗어 {damage}");
        ConditionHandler.TakeDamage(damage);
        Controller.Hitted();
        
    }


}
