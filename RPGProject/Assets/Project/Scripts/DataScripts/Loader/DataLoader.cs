using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class DataLoader<T> where T : LoadedDataBase
{
    private List<T> _itemList = new List<T>();
    private Dictionary<int, T> _itemDict = new Dictionary<int, T>();
    
    [Serializable]
    public class Wrapper
    {
        public List<T> items;
    }
    public DataLoader()
    {
        string jsonData = Resources.Load<TextAsset>($"Data/Json/{typeof(T).Name}").text;
        Wrapper wrapper = JsonConvert.DeserializeObject<Wrapper>(jsonData.Trim());
        _itemList = wrapper.items;
        foreach (T item in _itemList)
        {
            int id = item.id;
            _itemDict.Add(id, item);
        }
    }
    public T GetItem(int id)
    {
        if (_itemDict.ContainsKey(id))
        {
            return _itemDict[id];
        }
        return default;
    }
    public List<T> GetItemList()
    {
        return _itemList;
    }
}
