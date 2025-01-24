
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtention 
{
    public static float Distance(this Transform source, Transform target)
    {
        return Vector3.Distance(source.position, target.position);
    }
    public static Transform Closest(this Transform source, List<Transform> targets)
    {
        Transform closest = null;
        float minDistance = float.MaxValue;
        foreach (var target in targets)
        {
            float distance = (target.position - source.position).sqrMagnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = target;
            }
        }
        return closest;
    }
}
