using Newtonsoft.Json;
using UnityEngine;

public class ItemData
{
    public int InfoID { get; private set; }
    [JsonIgnore] public ItemInfo ItemInfo { get; private set; }
    [JsonIgnore] public bool IsStackable => ItemInfo.Stackable;
    [JsonIgnore] public int MaxCount => ItemInfo.MaxCount;
    [JsonIgnore] public ItemType ItemType  => ItemInfo.ItemType;
    
    public int Count { get; private set; }

    public ItemData(int infoID, int count = 0)
    {
        InfoID = infoID;
        ItemInfo = Managers.InfoManager.ItemLoader.GetItem(infoID);
        Count = count;
    }

    public Sprite Sprite { get; private set; }
    
    public int AddCount(int count)
    {
        if(count < 0)
        {
            return 0;
        }
        int remainCount = 0;
        if (ItemInfo.MaxCount > Count + count)
        {
            Count += count;
            remainCount = 0;
        }
        else
        {
            remainCount = Count + count - ItemInfo.MaxCount;
            Count = ItemInfo.MaxCount;
        }
        return remainCount;
    }
    public int RemoveCount(int count)
    {
        if(count < 0)
        {
            return 0;
        }
        int remainCount = 0;
        if (Count - count > 0)
        {
            Count -= count;
            remainCount = 0;
        }
        else
        {
            remainCount = count - Count;
            Count = 0;
        }
        return remainCount;
    }

    public int SetCount(int count)
    {
        int remainCount = 0;
        if(count < 0)
        {
            Count = 0;
        }
        else if(count > ItemInfo.MaxCount)
        {
            remainCount = count - ItemInfo.MaxCount;
            Count = ItemInfo.MaxCount;
        }
        else
        {
            Count = count;
        }
        return remainCount;
    }
    
    public override string ToString()
    {
        return $"{ItemInfo.Name} x {Count}";
    }
}



public class EquipData : ItemData
{
    public Stat Stat { get; private set; }
    
    public int Durability { get; private set; }
    public EquipData(int infoID, int count = 0) : base(infoID, count)
    {
    }
}