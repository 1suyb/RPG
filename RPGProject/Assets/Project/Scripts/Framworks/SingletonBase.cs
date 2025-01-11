using UnityEngine;

/// <summary>
/// 클래스를 싱글톤으로 만들어주는 부모 클래스
/// MonoBehaviour 붙어있음
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name;
                    instance = go.AddComponent<T>();
                    instance.InitOnCreate();
                }
            }
            return instance;
        }
    }
    /// <summary>
    /// 생성되자 마자 초기화를 수행하는 함수
    /// </summary>
    protected virtual void InitOnCreate(){}
}
