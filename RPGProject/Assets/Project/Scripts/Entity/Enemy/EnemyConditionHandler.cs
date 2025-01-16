using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConditionHandler : MonoBehaviour
{
    private Condition _hp;
    private Condition _shield;
    [SerializeField] private StatHandler _statHandler;
    private int _maxHp => _statHandler.CurrentStat.HP;
    private int _maxShield => _statHandler.CurrentStat.Shield;
    
    public void InitOnCreate(StatHandler statHandler)
    {
        _statHandler = statHandler;
        _hp = new Condition(_maxHp);
        _shield = new Condition(_maxShield);
    }

    public void TakeDamage(int damage)
    {
        if (_shield.CurrentValue > damage)
        {
            _shield.CurrentValue -= damage;
        }
        else
        {
            damage -= _shield.CurrentValue;
            _shield.CurrentValue = 0;
            _hp.CurrentValue -= damage;
        }
    }
    public void AddDieEvent(Action action)
    {
        _hp.OnExhaustCondition = action;
    }
    public void AddHpChangeEvent(Action<float> action)
    {
        _hp.OnChangeCondition = action;
    }
    public void AddShieldChangeEvent(Action<float> action)
    {
        _shield.OnChangeCondition = action;
    }
    public void AddTakeDamageEvent(Action action)
    {
        _hp.OnConsumeCondition = action;
        _shield.OnConsumeCondition = action;
    }
    public void AddHealEvent(Action action)
    {
        _hp.OnRecoveryCondition = action;
    }
    public void AddShieldRecoveryEvent(Action action)
    {
        _shield.OnRecoveryCondition = action;
    }
}
