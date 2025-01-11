using System;
using Manager;
using UnityEngine;

public class Projectile : MonoBehaviour, ILoadable
{
    private Transform _target;
    private Vector3 _dir;
    
    private AttackData _attackData;
    private ProjectileData _projectileData;
    
    private float _speed => _projectileData.Speed;
    private bool _isTracking => _projectileData.IsTracking;


    /// <summary>
    /// 생성시 id에 맞는 데이터를 로드해주는 함수
    /// 생성될 때 호출됨
    /// </summary>
    /// <param name="id"></param>
    public void Load(int id)
    {
        InitOnCreate();
        string filePath = ResourcePath.Prefab.Projectile(id.ToString());
        ResourceManager.Instantiate(filePath, parent:transform);
        _projectileData = new ProjectileData();
        _projectileData.Speed = 5f;
        _projectileData.IsTracking = true;
    }

    /// <summary>
    /// 생성 될 때 초기화를 수행하는 함수
    /// </summary>
    public virtual void InitOnCreate() {}

    /// <summary>
    ///  활성화 될때 데이터를 세팅하는 함수
    /// </summary>
    public virtual void InitOnActive(Transform target, AttackData attackData)
    {
        _target = target;
        _attackData = attackData;
        _dir = (_target.position - transform.position).normalized;
    }

    protected void OnDisable()
    {
        _target = null;
        _attackData = null;
        _dir = Vector3.zero;
    }

    /// <summary>
    /// projectile의 이동 업데이트 함수
    /// </summary>
    public virtual void UpdateProjectile()
    {
        if (_target == null)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            if (_isTracking)
            {
                _dir = (_target.position - transform.position).normalized;
                transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(_dir), Time.deltaTime * 10f);
            }
            transform.position += _speed * Time.deltaTime * _dir;
        }
    }
    
}

