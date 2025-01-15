using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConditionHandler : MonoBehaviour
{
    private Condition _hp;
    private Condition _shield;
    [SerializeField] private StatHandler _statHandler;
    private int _maxHp => _statHandler.CurrentStat.HP;
    
    
    public void InitOnCreate(StatHandler statHandler)
    {
        _statHandler = statHandler;
        _hp = new Condition(_maxHp);
        _shield = new Condition();
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
}
