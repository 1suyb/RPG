using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable , IHealable
{
    [field:SerializeField] public string Name { get; private set; }
    [field:SerializeField] public CharacterStateMachine StateMachine { get; private set; }
    [field:SerializeField] public StatHandler StatHandler { get; private set; }
    [field:SerializeField] public CharacterConditionHandler ConditionHandler { get; private set; }
    [field:SerializeField] public CharacterBuffReceiver BuffReceiver { get; private set; }
    [field:SerializeField] public CharacterEquipmentHandler EquipmentHandler { get; private set; }
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
        Debug.Log("회복!");
    }

    public void ReceiveBuff(BuffInfo info)
    {
        BuffReceiver.AddBuff(info);
    }
    public void EquipItem(EquipItem item)
    {
        EquipmentHandler.Equip(item);
    }
    public void UnequipItem(EquipItem item)
    {
        EquipmentHandler.UnequipItem(item);
    }
}
