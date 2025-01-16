
using System;
using UnityEngine;

public class EnemyAnimationEventReceiver : MonoBehaviour
{
    public event Action OnEndAnimationEvent;
    public void EndAnimation()
    {
        OnEndAnimationEvent?.Invoke();
    }
}
