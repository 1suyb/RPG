using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtention
{
    public static T GetComponentInDirectChild<T>(this GameObject go) where T : Component
    {
        foreach (Transform child in go.transform)
        {
            T component = child.GetComponent<T>();
            if (component != null)
            {
                return component;
            }
        }

        return null;
    }
}
