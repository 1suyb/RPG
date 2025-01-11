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
    
    public GameObjectFactoryBase(string path, int minSize = 0, int maxSize = 10, Transform root = null)
    {
        InitOnCreate(ResourceManager.Load<GameObject>(path), minSize, maxSize, root);
    }
    public GameObjectFactoryBase(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null)
    {
        InitOnCreate(prefab, minSize, maxSize, root);
    }

    /// <summary>
    /// 생성자에서 실행되는 함수
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <param name="root"></param>
    protected virtual void InitOnCreate(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null)
    {
        this._prefab = prefab;
        _poolMinSize = minSize;
        _poolMaxSize = maxSize;
        _pool = new Dictionary<int, GameObjectPool>();
        _root = root;
    }
    
    private bool CheckPool(int id) => _pool.ContainsKey(id);

    private void SetPool(int id)
    {
        _pool.Add(id, new GameObjectPool(_prefab, id, _poolMinSize, _poolMaxSize,_root));
    }
    
    /// <summary>
    /// 풀에서 오브젝트를 꺼낼 때 초기화 작업을 수행할 수 있도록 하는 함수
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public virtual T InitObjOnActivate(T obj)
    {
        return obj.GetComponent<T>();
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
