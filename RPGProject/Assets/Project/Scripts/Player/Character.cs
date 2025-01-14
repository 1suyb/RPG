using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field:SerializeField] public CharacterStateMachine StateMachine { get; private set; }
    [field:SerializeField] public CharacterStatHandler StatHandler { get; private set; }
    [field:SerializeField] public CharacterConditionHandler ConditionHandler { get; private set; }
    [field:SerializeField] public AttackData CurrentAttackData { get; private set; }
    [field:SerializeField] public LayerMask TargetLayer { get; private set; }
    [field:SerializeField] public Transform Target { get; private set; }
    public void Start()
    {
        StateMachine.Init(this);
    }
    
    
    
}
