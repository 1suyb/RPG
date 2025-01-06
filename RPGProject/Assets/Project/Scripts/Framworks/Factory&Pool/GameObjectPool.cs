using System;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class GameObjectPool
{
    private Stack<GameObject> _pool = new Stack<GameObject>();
    private readonly GameObject _targetObject;
    private readonly int _id;
    private readonly int _maxsize;
    private int _poolSize;
    private readonly Func<GameObject> _createObject;
    private Transform _root;
    public bool IsPoolEmpty => _pool.Count == 0;

    public GameObjectPool(GameObject targetObject, int id=-1, int minSize=0, int maxSize=10,Transform root = null, Func<GameObject> createObject=null)
    {
        this._targetObject = targetObject;
        this._id = id;
        this._maxsize = maxSize;
        this._createObject = createObject;
        this._root = root;
        for(int i = 0; i < minSize; i++)
        {
            CreateItem(root:root);
        }
    }

    public GameObject TakeFromPool(Transform transform = null)
    {
        if (IsPoolEmpty)
        {
            return CreateItem(transform);
        }
        GameObject obj = _pool.Pop();
        obj.gameObject.SetActive(true);
        return obj;
    }

    private GameObject CreateItem(Transform root = null)
    {
        GameObject go;
        if (_createObject != null)
        {
            go = _createObject();
        }
        else
        {
            go = ResourceManager.Instantiate(_targetObject,root? root : _root);
        }
        PooledObject pooledItem = go.AddComponent<PooledObject>();
        pooledItem.Init(this, _id);
        _poolSize++;
        go.SetActive(false);
        return go;
    }
	
    public void Release(GameObject go)
    {
        if(_poolSize > _maxsize)
        {
            GameObject.Destroy(go.gameObject);
            _poolSize--;
            return;
        }
        _pool.Push(go);
    }

    public void Clear()
    {
        _pool.Clear();
    }
}