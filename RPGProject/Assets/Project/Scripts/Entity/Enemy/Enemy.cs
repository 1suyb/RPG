using System;
using UnityEngine;

public class Enemy : Entity
{
    [field : Header("Status")]
    [field:SerializeField] public StatHandler StatHandler { get; private set; }
    [field:SerializeField] public EnemyConditionHandler ConditionHandler { get; private set; }
    [field:Header("Action")]
    [field:SerializeField] public EnemyController Controller { get; private set; }
    [field:SerializeField] public EnemyAI AI { get; private set; }
    
    [field:SerializeField] public AttackData CurrentAttackData { get; private set; }

    public Stat CurrentStat => StatHandler.CurrentStat;
    
    public override event Action OnDie;
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
        AI.SetState(EnemyState.Die);
    }

    public override void TakeDamage(AttackHandler attackHandler)
    {
        int damage = attackHandler.CalculateDamage(CurrentStat);
        Debug.Log($"나맞앗어 {damage}");
        ConditionHandler.TakeDamage(damage);
        AI.SetState(EnemyState.Hit);
        
    }

    public override void ReceiveHealing()
    {
        Debug.Log("회복!");
    }
}
