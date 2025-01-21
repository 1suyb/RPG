using Manager;
using Newtonsoft.Json;
using UnityEngine;

public class ItemData
{
    public int ID { get; private set; }
    public int InfoID { get; private set; }
    [JsonIgnore] public ItemInfo ItemInfo { get; private set; }
    [JsonIgnore] public bool IsStackable => ItemInfo.Stackable;
    [JsonIgnore] public int MaxCount => ItemInfo.MaxCount;
    [JsonIgnore] public ItemType ItemType  => ItemInfo.ItemType;
    
    private int _count;
    [JsonIgnore] public int Count
    {
        get => _count;
        set => _count = IsStackable ? Mathf.Clamp(value, 0, MaxCount) : 1;
    }
    public Sprite Sprite { get; private set; }
    
    public bool IsFull => Count >= MaxCount;
    
    public ItemData(ItemInfo info, int count)
    {
        InfoID = info.ID;
        ItemInfo = info;
        Count = count;
        string spritePath = ResourcePath.Sprite.ItemSprite(info.ID.ToString());
        Sprite = ResourceManager.Load<Sprite>(spritePath);
    }
    
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
        if (Count <= 0)
        {
            Count = 0;
        }
        return Count;
    }
}

public class ItemFactory
{
    private ItemInfoLoader _itemLoader;
    
    private InfoLoader<ItemInfo> itemInfo => _itemLoader.ItemLoader;
    private InfoLoader<EquipItemInfo> equipItemInfo => _itemLoader.EquipItemLoader;
    private InfoLoader<ConsumeItemInfo> consumeItemInfo => _itemLoader.ConsumeItemLoader;
    private InfoLoader<MaterialItemInfo> materialItemInfo => _itemLoader.MaterialItemLoader;
    
    
    public ItemFactory()
    {
        _itemLoader = Managers.InfoManager.ItemInfoLoader;
    }
    
    public ItemData CreateItem(int infoID, int count = 0)
    {
        ItemInfo info = itemInfo.GetItem(infoID);
        switch (info.ItemType)
        {
            case ItemType.Equipment:
                EquipItemInfo equipInfo = equipItemInfo.GetItem(info.EquipID);
                return new EquipData(info,equipInfo, count);
            case ItemType.Consume:
                ConsumeItemInfo consumeInfo = consumeItemInfo.GetItem(info.ComsumeID);
                return new ConsumableData(info,consumeInfo, count);
            case ItemType.Material:
                MaterialItemInfo materialInfo = materialItemInfo.GetItem(info.ResourceID);
                return new MaterialData(info,materialInfo, count);
            default:
                return new ItemData(info, count);
        }
    }
}

public class EquipData : ItemData
{
    public EquipItemInfo EquipItemInfo { get; private set; }
    public Stat Stat { get; private set; }
    public int Durability { get; private set; }
    
    public EquipData(ItemInfo info, EquipItemInfo equipInfo, int count = 0) : base(info, count)
    {
        EquipItemInfo = equipInfo;
    }
}
public class ConsumableData : ItemData
{
    public ConsumeItemInfo ConsumeItemInfo { get; private set; }
    
    public ConsumableData(ItemInfo info, ConsumeItemInfo equipInfo, int count = 0) : base(info, count)
    {
        ConsumeItemInfo = equipInfo;
    }
}
public class MaterialData : ItemData
{
    public MaterialItemInfo MaterialItemInfo { get; private set; }
    public MaterialData(ItemInfo info, MaterialItemInfo equipInfo, int count = 0) : base(info, count)
    {
        MaterialItemInfo = equipInfo;
    }
}