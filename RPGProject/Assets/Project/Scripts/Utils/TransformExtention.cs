
using UnityEngine;

public static class TransformExtention 
{
    public static float Distance(this Transform source, Transform target)
    {
        return Vector3.Distance(source.position, target.position);
    }
}
