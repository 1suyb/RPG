using UnityEngine;

namespace Manager
{
    public class ResourceManager
    {
        public static GameObject Instantiate(string path, Transform parent = null)
        {
            GameObject prefab = Load<GameObject>(path);
            return Instantiate(prefab, parent);
        }
    
        public static GameObject Instantiate(GameObject prefab, Transform parent = null)
        {
            if (prefab != null)
            {
                return Object.Instantiate(prefab, parent);
            }
            return null;
        }
    
        public static T Load<T> (string path) where T : Object
        {
#if RESOURCES
            return Resources.Load<T>(path);
#endif
#if ADDRESSABLES
            return Addressables.LoadAsset<T>(path).Result;
            Debug.LogWarning("No Asset Loading Method Defined");
            return null;
#endif
        }
    }
}

