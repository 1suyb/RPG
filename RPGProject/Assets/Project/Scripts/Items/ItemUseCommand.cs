using UnityEngine;

public abstract class ItemUseCommand : ICommand
{
    protected Item _item;
    protected Character _character;
    
    public ItemUseCommand(Item item, Character character)
    {
        _item = item;
        _character = character;
    }

    public abstract void Execute();
}

public class EquipItemCommand : ItemUseCommand
{
    public EquipItemCommand(Item item, Character character) : base(item,character)
    {
    }

    public override void Execute()
    {
        Debug.Log($"{_item.ItemData.Name} by {_character.Name}");;
        EquipItem equipItem = _item as EquipItem;
        if (equipItem == null) return;
        equipItem.IsEquipped = !equipItem.IsEquipped;
        
    }
}

public class ConsumableItemCommand : ItemUseCommand
{
    public ConsumableItemCommand(Item item, Character character) : base(item,character)
    {
    }

    public override void Execute()
    {
        Debug.Log($"{_item.ItemData.Name} by {_character.Name}");
        ConsumableData consumeItemInfo = _item.ItemData as ConsumableData;
        if (consumeItemInfo == null) return;
        BuffInfo buffInfo = Managers.InfoManager.BuffLoader.GetItem(consumeItemInfo.BuffID);
        _character.ReceiveBuff(buffInfo);
    }
}

