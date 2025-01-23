using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable , IHealable
{
    [field:SerializeField] public CharacterStateMachine StateMachine { get; private set; }
    [field:SerializeField] public StatHandler StatHandler { get; private set; }
    [field:SerializeField] public CharacterConditionHandler ConditionHandler { get; private set; }
    [field:SerializeField] public AttackData CurrentAttackData { get; private set; }
    [field:SerializeField] public LayerMask TargetLayer { get; private set; }
    [field:SerializeField] public Transform Target { get; private set; }
    public void Start()
    {
        StateMachine.Init(this);
    }


    public void TakeDamage(AttackHandler attackHandler)
    {
        Debug.Log("맞았따");
    }

    public void ReceiveHealing()
    {
        throw new NotImplementedException();
    }
}
