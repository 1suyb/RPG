using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    private List<ItemData> _itemList = new List<ItemData>();
    public List<ItemData> ItemList => _itemList;
    private int _maxCount = 20;

    private bool _isFull => _itemList.Count >= _maxCount;
    
    public Inventory()
    {
        _itemList = new List<ItemData>();
    }
    public int AddItem(ItemData item)
    {
        if (item.IsStackable)
        {
            return AddStackableItem(item);
        }
        else
        {
            return AddNonStackableItem(item);
        }
    }
    
    private int AddStackableItem(ItemData item)
    {
        int index = FindItemIndex(item.InfoID);
        int remainCount = 0;
        if (index < 0)
        {
            ItemData newItem = new ItemData(item.InfoID);
            remainCount = newItem.AddCount(item.Count);
            _itemList.Add(newItem);

        }
        else
        {
            remainCount= _itemList[index].AddCount(item.Count);
        }
        
        if (remainCount > 0)
        {
            if (_isFull)
            {
                return remainCount;
            }
            else
            {
                ItemData newItem = new ItemData(item.InfoID);
                remainCount = newItem.AddCount(remainCount);
                _itemList.Add(newItem);
                item.SetCount(remainCount);
                AddStackableItem(item);

            }
        }
        return 0;
    }
    private int AddNonStackableItem(ItemData item)
    {
        if (_isFull)
        {
            return item.Count;
        }
        else
        {
            ItemData newItem = new ItemData(item.InfoID);
            newItem.AddCount(item.Count);
            _itemList.Add(newItem);
            return 0;
        }
    }
    private int FindItemIndex(int infoID)
    {
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList[i].InfoID == infoID)
            {
                return i;
            }
        }
        return -1;
    }
    public void RemoveItem(int index, int count)
    {
        if (index < 0)
        {
            return;
        }
        int remainCount = _itemList[index].RemoveCount(count);
        if (remainCount == 0)
        {
            _itemList.RemoveAt(index);
        }
    }
}
