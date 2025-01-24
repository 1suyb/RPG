using System;
using UnityEngine;

public class Character :Entity
{
    [field:Header("Controller")]
    [field:SerializeField] public CharacterStateMachine StateMachine { get; private set; }
    [field:SerializeField] public EntityController Controller { get; private set; }
    [field:Header("Status")]
    [field:SerializeField] public StatHandler StatHandler { get; private set; }
    [field:SerializeField] public CharacterConditionHandler ConditionHandler { get; private set; }
    [field:SerializeField] public CharacterBuffReceiver BuffReceiver { get; private set; }
    [field:SerializeField] public CharacterEquipmentHandler EquipmentHandler { get; private set; }
    
    
    [field:SerializeField] public string Name { get; private set; }
    [field:SerializeField] public AttackData CurrentAttackData { get; private set; }
     
    
    public void Start()
    {
        StateMachine.Init(this);
    }
    
    public override void TakeDamage(AttackHandler attackHandler)
    {
        Debug.Log("맞았따");
    }

    public override void ReceiveHealing()
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
