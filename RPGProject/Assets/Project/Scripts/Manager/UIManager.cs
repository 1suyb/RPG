using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class UIManager : SingletonBase<UIManager>
    {
        private Dictionary<UIType, UIBase> _uiCache = new Dictionary<UIType, UIBase>();

        public UIManager()
        {
        }

        public T Get<T>(UIType type) where T : UIBase
        {
            if (_uiCache.ContainsKey(type))
            {
                return _uiCache[type] as T;
            }
            else
            {
                T ui = ResourceManager.Instantiate(UIPath.Path[type]).GetComponent<T>();
                _uiCache.Add(type, ui);
                ui.gameObject.SetActive(false);
                return ui;
            }
        }

        public T Open<T>(UIType type) where T : UIBase
        {
            T ui = Get<T>(type);
            ui.Open();
            return ui;
        }

        public T Close<T>(UIType type) where T : UIBase
        {
            T ui = Get<T>(type);
            ui.Close();
            return ui;
        }

        public void Toast(string message, float time = 2f)
        {
            
        }
        public void Alert(string message)
        {
            
        }
        public void Confirm(string message, System.Action onConfirm)
        {
            
        }
    }
}

