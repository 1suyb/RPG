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
}
