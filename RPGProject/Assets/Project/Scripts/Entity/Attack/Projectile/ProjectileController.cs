using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ProjectileData
{
    public float Speed;
    public bool IsTracking;
}


public class ProjectileController : SingletonBase<ProjectileController>
{
    ProjectileFactory _projectileFactory;
    List<Projectile> _projectiles;

    protected override void InitOnCreate()
    {
        base.InitOnCreate();
        _projectileFactory = new ProjectileFactory(ResourcePath.BasePrefab.Projectile, 0, 50, transform);
        _projectiles = new List<Projectile>();
    }

    public void CreateProjectile(int id,Transform target, LayerMask layer, AttackHandler attackHandler, Vector3 position = default, Quaternion rotate = default)
    {
        Projectile projectile = _projectileFactory.Create(id);
        projectile.transform.SetPositionAndRotation(position, rotate);
        projectile.InitOnActive(target, layer, attackHandler);
        _projectiles.Add(projectile);
    }
    
    public void RemoveProjectile(Projectile projectile)
    {
        _projectiles.Remove(projectile);
    }
    
    public void Update()
    {
        for (int i = 0; i < _projectiles.Count; i++)
        {
            _projectiles[i].UpdateProjectile();
        }
    }
}

public class ProjectileFactory : GameObjectFactoryBase<Projectile>
{
    public ProjectileFactory(string path, int minSize = 0, int maxSize = 10, Transform root = null) : base(path, minSize, maxSize, root)
    {
    }
    public ProjectileFactory(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null) : base(prefab, minSize, maxSize, root)
    {
    }
}