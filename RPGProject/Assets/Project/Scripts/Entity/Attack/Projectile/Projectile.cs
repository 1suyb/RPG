using System;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class Projectile : AttackBase, ILoadable
{
    private Transform _target;
    private Vector3 _dir;
    
    private ProjectileData _projectileData;
    private ProjectileCollider _projectileCollider;
    private AttackHandler _attackHandler;
    
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
        GameObject obj = ResourceManager.Instantiate(filePath, parent:transform);
        _projectileCollider = obj.GetComponent<ProjectileCollider>();
        _projectileCollider.OnHit += Hit;
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
    public virtual void InitOnActive(Transform target, LayerMask layer, AttackHandler attackHandler)
    {
        _attackHandler = attackHandler;
        
        _target = target;
        _targetLayer = layer;
        _dir = (_target.position - transform.position).normalized;
        _dir.y = 0;
        
        _projectileCollider.InitOnActivate(_targetLayer);
    }

    protected void OnDisable()
    {
        ProjectileController.Instance.RemoveProjectile(this);
        _target = null;
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
                _dir.y = 0;
                transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(_dir), Time.deltaTime * 10f);
            }
            transform.position += _speed * Time.deltaTime * _dir;
        }
    }

    public virtual void Hit(Collider collider)
    {
        DealDamage(collider, _targetLayer, _attackHandler, transform);
        this.gameObject.SetActive(false);
    }
}

