using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserItemDB
{
    private List<ItemData> _items;
    private Item[] _inventory;
    
    public UserItemDB()
    {
        _items = new List<ItemData>();
        
    }
    public ItemData FindItem(int id)
    {
        return _items.Find(item => item.ID == id);
    }
    
    public ItemData FindItem(ItemInfo info)
    {
        return _items.Find(item => item.ItemInfo == info);
    }
// DB에 이 Info를 가진 아이템이 있냐?
// 있으면 그 아이템의 count를 증가
// 없으면 새로 만들어서 넣기

    public void AddItem(ItemInfo info, int count)
    {
        ItemData item = FindItem(info);
        if(item != null)
        {
            item.AddCount(count);
        }
        else
        {
            item = Managers.FactoryManager.ItemDataFactory.CreateItem(info, count);
            _items.Add(item);
        }
    }

    public void RemoveItem(ItemInfo info, int count)
    {
        ItemData item = FindItem(info);
        if(item == null)
        {
            return;
        }
        item.RemoveCount(count);
        if(item.Count <= 0)
        {
            _items.Remove(item);
        }
    }
}

