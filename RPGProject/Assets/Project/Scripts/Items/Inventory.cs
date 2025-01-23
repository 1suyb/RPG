using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    ItemFactory _itemFactory;
    private Item[] _itemList;
    public Item[] ItemList => _itemList;
    private int _maxCount = 80;

    private bool _isFull {
        get
        {
            return FindEmptyIndex() == -1;
        } 
    }
    public Item this[int index]
    {
        get
        {
            if (index < 0 || index >= _itemList.Length)
            {
                return null;
            }
            return _itemList[index];
        }
    }

    public Inventory()
    {
        _itemList = new Item[_maxCount];
        _itemFactory = new ItemFactory();
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
        Item newItem = _itemFactory.CreateItem(info.ID, remainCount);
        int index = FindEmptyIndex();
        _itemList[index] = newItem;
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
            Item newItem = _itemFactory.CreateItem(info.ID, count);
            int index = FindEmptyIndex();
            _itemList[index] = newItem;
            return 0;
        }
    }
    private int FindItemIndex(int infoID, int startIndex = 0)
    {
        for (int i = startIndex; i < _itemList.Length; i++)
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
        for (int i = 0; i < _itemList.Length; i++)
        {
            if(_itemList[i] == null)
            {
                continue;
            }
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
            _itemList[index] = null;
        }
    }

    public int FindEmptyIndex()
    {
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (_itemList[i] == null)
            {
                return i;
            }
        }

        return -1;
    }
    

    public void Swap(int i, int j)
    {
        (_itemList[i], _itemList[j]) = (_itemList[j], _itemList[i]);
    }
}
