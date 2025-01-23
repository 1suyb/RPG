using Manager;
using Newtonsoft.Json;
using UnityEngine;

public class ItemData
{
    public int ID { get; private set; }
    public int InfoID { get; private set; }
    [JsonIgnore] public ItemInfo ItemInfo { get; private set; }
    public string Name => ItemInfo.Name;
    public string Description => ItemInfo.Description;
    public ItemType ItemType  => ItemInfo.ItemType;
    public int Price => ItemInfo.Price;
    public bool Sell => ItemInfo.Sell; 
    public bool Destory => ItemInfo.Destory;
    public bool IsStackable => ItemInfo.Stackable;
    public int MaxCount => ItemInfo.MaxCount;
    
    private int _count;
    public int Count => _count;
    public Sprite Sprite { get; private set; }
    
    public bool IsFull => _count >= MaxCount;
    
    public ItemData(ItemInfo info, int count = 1)
    {
        InfoID = info.ID;
        ItemInfo = info;
        _count = count;
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
            _count += count;
        }
    }
    
    public int RemoveCount(int count)
    {
        if (count < 0)
        {
            return 0;
        }
        _count -= count;
        if (_count <= 0)
        {
            _count = 0;
        }
        return _count;
    }
}

public class EquipData : ItemData
{
    public EquipItemInfo EquipItemInfo { get; private set; }
    public EquipType EquipType => EquipItemInfo.EquipmentType;
    public Stat Stat { get; private set; }
    public int Durability { get; private set; }
    // public int MaxDurability => EquipItemInfo.MaxDurability;
    public bool IsBroken => Durability <= 0;
    
    public EquipData(ItemInfo info, EquipItemInfo equipInfo, int count = 0) : base(info, count)
    {
        EquipItemInfo = equipInfo;
        StatBuilder statBuilder = new StatBuilder();
        Stat = statBuilder.SetHP(equipInfo.MaxHp)
            .SetMP(equipInfo.MaxMp)
            .SetShield(equipInfo.MaxShield)
            .SetHunger(equipInfo.MaxHunger)
            .SetPhysicalAttack(equipInfo.PhysicalAttack)
            .SetMagicalAttack(equipInfo.MagicalAttack)
            .SetPhysicalDefence(equipInfo.PhysicalDefence)
            .SetMagicalDefence(equipInfo.MagicalDefence)
            .SetCriticalChance(equipInfo.CriticalChance)
            .SetCriticalMultiplier(equipInfo.CriticalMultiplier)
            .Build();
    }
}
public class ConsumableData : ItemData
{
    public ConsumeItemInfo ConsumeItemInfo { get; private set; }
    // 쿨타임
    public int BuffID => ConsumeItemInfo.BuffID;
    
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