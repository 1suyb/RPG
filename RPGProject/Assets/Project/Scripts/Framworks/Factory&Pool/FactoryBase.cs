using System;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class GameObjectFactoryBase<T> where T : Component
{
    private Dictionary<int,GameObjectPool> _pool;
    private int _poolMinSize;
    private int _poolMaxSize;
    private GameObject _prefab;
    private Transform _root;
    private Action<GameObject> _createObject;
    
    public GameObjectFactoryBase(string path, int minSize = 0, int maxSize = 10, Transform root = null, Action<GameObject> createObject=null)
    {
        InitOnCreate(ResourceManager.Load<GameObject>(path), minSize, maxSize, root, createObject);
    }
    public GameObjectFactoryBase(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null, Action<GameObject> createObject=null)
    {
        InitOnCreate(prefab, minSize, maxSize, root, createObject);
    }
    
    protected virtual void InitOnCreate(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null, Action<GameObject> createObject=null)
    {
        this._prefab = prefab;
        _poolMinSize = minSize;
        _poolMaxSize = maxSize;
        _pool = new Dictionary<int, GameObjectPool>();
        _root = root;
        _createObject = createObject;
    }
    
    private bool CheckPool(int id) => _pool.ContainsKey(id);

    private void SetPool(int id)
    {
        _pool.Add(id, new GameObjectPool(_prefab, id, _poolMinSize, _poolMaxSize,_root, _createObject));
    }
    
    /// <summary>
    /// 풀에서 오브젝트를 꺼낼 때 초기화 작업을 수행할 수 있도록 하는 함수
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public virtual T InitObjOnActivate(T obj)
    {
        return obj;
    }
    
    /// <summary>
    /// 오브젝트는 Setactivae ture 상태로 꺼내져 나옴
    /// 필요한 초기화 과정이 있으면 InitObj 함수를 오버라이딩하여 사용
    /// </summary>
    /// <param name="id"></param>
    /// <param name="root"></param>
    /// <returns></returns>
    public T Create(int id = -1, Transform root = null)
    {
        if (!CheckPool(id))
        {
            SetPool(id);
        }
        
        T obj =  _pool[id].TakeFromPool(root).GetComponent<T>();
        return InitObjOnActivate(obj);
    }
}

public class Factory<T,R> where T : LoadedInfoBase
{
    private InfoLoader<T> _loader;
    public Factory()
    {
    }

    public virtual R Create(int id)
    {
        return default;
    }
}