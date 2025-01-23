using Newtonsoft.Json;
using UnityEngine;

[SerializeField]
public class Item
{
    public int ID;
    public int InfoID => _itemData.InfoID;
    
    private ItemData _itemData;
    public ItemData ItemData => _itemData;
    public ItemType ItemType => _itemData.ItemType;
    [JsonProperty] private int _count;
    public int Count
    {
        get => _count;
        set => _count = _itemData.IsStackable ? Mathf.Clamp(value, 0, _itemData.MaxCount) : 1;
    }
    
    public bool IsFull => _count >= _itemData.MaxCount;
    
    public Item(ItemData itemData, int count)
    {
        _itemData = itemData;
        Count = count;
    }

    public bool IsStackable => _itemData.IsStackable;
    
    public void AddCount(int count)
    {
        if(count < 0)
        {
            return ;
        }
        if (IsStackable)
        {
            Count += count;
        }
    }
    public int RemoveCount(int count)
    {
        if (count < 0)
        {
            return 0;
        }
        Count -= count;
        if (_count <= 0)
        {
            Count = 0;
        }
        return _count;
    }
    
    public void UseItem()
    {
        switch(_itemData.ItemType)
        {
            case ItemType.Equipment:
                ICommand equipCommand = new EquipItemCommand(this);
                equipCommand.Execute();
                break;
            case ItemType.Consume:
                ICommand consumableCommand = new ConsumableItemCommand(this);
                consumableCommand.Execute();
                break;
        }
    }
}

public class EquipItem : Item
{
    private EquipData _equipData;
    public bool IsEquipped;
    public EquipItem(ItemData itemData, int count) : base(itemData, count)
    {
        IsEquipped = false;
        _equipData = itemData as EquipData;
    }
}


public class ItemFactory
{
    public Item CreateItem(int infoID, int count = 0)
    {
        ItemData itemData = Managers.FactoryManager.ItemDataFactory.CreateItem(infoID, count);
        return new Item(itemData, count);
    }
    
}