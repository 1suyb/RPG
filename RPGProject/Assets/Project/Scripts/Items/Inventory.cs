using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    private ItemFactory _itemFactory;
    private List<ItemData> _itemList = new List<ItemData>();
    public List<ItemData> ItemList => _itemList;
    private int _maxCount = 20;

    private bool _isFull => _itemList.Count >= _maxCount;
    
    public Inventory()
    {
        _itemList = new List<ItemData>();
        _itemFactory = Managers.FactoryManager.ItemFactory;
    }
    
    public int AddItem(ItemInfo item, int count)
    {
        if (item.Stackable)
        {
            return AddStackableItem(item, count);
        }
        else
        {
            return AddNonStackableItem(item,count);
        }
    }
    
    private int AddStackableItem(ItemInfo info, int count)
    {
        int remainCount = count;
        List<int> indices = FindItemIndices(info.ID);
        if (indices.Count >0)
        {
            for(int i = 0; i < indices.Count; i++)
            {
                if(_itemList[indices[i]].IsFull)
                {
                    continue;
                }
                remainCount = count + _itemList[indices[i]].Count - info.MaxCount;
                _itemList[indices[i]].AddCount(count);
            }
        }
        if(_isFull)
        {
            return count;
        }
        if(remainCount <= 0)
        {
            return 0;
        }
        ItemData newItem = _itemFactory.CreateItem(info.ID, remainCount);
        _itemList.Add(newItem);
        remainCount -= info.MaxCount;
        
        if(remainCount > 0 )
            remainCount = AddStackableItem(info, remainCount);
        return remainCount;
    }
    private int AddNonStackableItem(ItemInfo info, int count)
    {
        if (_isFull)
        {
            return count;
        }
        else
        {
            ItemData newItem = _itemFactory.CreateItem(info.ID, count);
            newItem.AddCount(count);
            _itemList.Add(newItem);
            return 0;
        }
    }
    private int FindItemIndex(int infoID, int startIndex = 0)
    {
        for (int i = startIndex; i < _itemList.Count; i++)
        {
            if (_itemList[i].InfoID == infoID)
            {
                return i;
            }
        }
        return -1;
    }
    private List<int> FindItemIndices(int infoID)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList[i].InfoID == infoID)
            {
                indices.Add(i);
            }
        }
        return indices;
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
