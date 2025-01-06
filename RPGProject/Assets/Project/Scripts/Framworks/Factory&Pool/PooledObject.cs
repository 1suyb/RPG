using UnityEngine;

public class PooledObject : MonoBehaviour 
{
    private GameObjectPool _pool;
    private int _id;

    public void Init(GameObjectPool pool, int id)
    {
        this._pool = pool;
        this._id = id;
        if(this.GetComponent<ILoadable>() != null)
        {
            this.GetComponent<ILoadable>().Load(id);
        }
    }

    private void OnDisable()
    {
        _pool.Release(this.gameObject);
    }
}

