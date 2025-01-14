using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConditionHandler : MonoBehaviour
{
    private Condition _hp;
    private Condition _shield;
    [SerializeField] private int _maxHp;
    
    public void InitOnCreate()
    {
        _hp = new Condition(_maxHp);
        _shield = new Condition();
    }
}
