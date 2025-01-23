using UnityEngine;

public abstract class ItemUseCommand : ICommand
{
    protected ItemData _item;
    protected Character _character;
    
    public ItemUseCommand(ItemData item, Character character)
    {
        _item = item;
        _character = character;
    }

    public abstract void Execute();
}

public class EquipItemCommand : ItemUseCommand
{
    public EquipItemCommand(ItemData item, Character character) : base(item, character)
    {
    }

    public override void Execute()
    {
        Debug.Log($"{_item.Name}");
    }
}
public class ConsumableItemCommand : ItemUseCommand
{
    public ConsumableItemCommand(ItemData item, Character character) : base(item, character)
    {
    }

    public override void Execute()
    {
        Debug.Log($"{_item.Name}");
    }
}

