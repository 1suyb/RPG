using UnityEngine;

public abstract class ItemUseCommand : ICommand
{
    protected Item _item;
    protected Character _character;
    
    public ItemUseCommand(Item item)
    {
        _item = item;
        //_character = character;
    }

    public abstract void Execute();
}

public class EquipItemCommand : ItemUseCommand
{
    public EquipItemCommand(Item item) : base(item)
    {
    }

    public override void Execute()
    {
        Debug.Log($"{_item.ItemData.Name}");
        EquipItem equipItem = _item as EquipItem;
        if (equipItem == null) return;
        equipItem.IsEquipped = !equipItem.IsEquipped;
        
    }
}
public class ConsumableItemCommand : ItemUseCommand
{
    public ConsumableItemCommand(Item item) : base(item)
    {
    }

    public override void Execute()
    {
        Debug.Log($"{_item.ItemData.Name}");
    }
}

