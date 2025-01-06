using System.Collections.Generic;
using UnityEngine;
using Manager;

public class GameObjectFactoryBase<T> where T : Component
{
    private Dictionary<int,GameObjectPool> _pool;
    private int _poolMinSize;
    private int _poolMaxSize;
    private GameObject _prefab;
    
    public GameObjectFactoryBase(string path, int minSize = 0, int maxSize = 10, Transform root = null)
    {
        Init(ResourceManager.Load<GameObject>(path), minSize, maxSize, root);
    }
    public GameObjectFactoryBase(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null)
    {
        Init(prefab, minSize, maxSize, root);
    }

    private void Init(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null)
    {
        this._prefab = prefab;
        _poolMinSize = minSize;
        _poolMaxSize = maxSize;
        _pool = new Dictionary<int, GameObjectPool>();
    }
    
    private bool CheckPool(int id) => _pool.ContainsKey(id);

    protected virtual void SetPool(int id)
    {
        _pool.Add(id, new GameObjectPool(_prefab, id, _poolMinSize, _poolMaxSize));
    }
    
    public virtual T Create(int id = -1, Transform root = null)
    {
        if (!CheckPool(id))
        {
            SetPool(id);
        }
        return _pool[id].TakeFromPool(root).GetComponent<T>();
    }
}
