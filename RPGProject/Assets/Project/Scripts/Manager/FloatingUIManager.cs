using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class FloatingUIManager : SingletonBase<FloatingUIManager>
    {
        private Canvas _floatingUICanvas;
        private FloatingHpbarFactory _floatingHpbarFactory;
        private Camera _camera;

        private List<FloatingUIBase> _floatingUIList = new List<FloatingUIBase>();
        protected override void InitOnCreate()
        {
            base.InitOnCreate();
            _camera = Camera.main;
            _floatingUICanvas = ResourceManager.Instantiate(UIPath.RootCanvas).GetComponent<Canvas>();
            _floatingHpbarFactory = new FloatingHpbarFactory(ResourcePath.Prefab.FloatingHpBar, 0, 100, _floatingUICanvas.transform);
        }
        
        public void CreateFloatingHpBar(Transform target)
        {
            FloatingHpBar floatingHpBar = _floatingHpbarFactory.Create();
            floatingHpBar.InitOnActivate(target);
        }
        
        
    }

}

public class FloatingHpbarFactory : GameObjectFactoryBase<FloatingHpBar>
{
    public FloatingHpbarFactory(string path, int minSize = 0, int maxSize = 10, Transform root = null, Action<GameObject> createObject = null) : base(path, minSize, maxSize, root, createObject)
    {
    }

    public FloatingHpbarFactory(GameObject prefab, int minSize = 0, int maxSize = 10, Transform root = null, Action<GameObject> createObject = null) : base(prefab, minSize, maxSize, root, createObject)
    {
    }
    
}
