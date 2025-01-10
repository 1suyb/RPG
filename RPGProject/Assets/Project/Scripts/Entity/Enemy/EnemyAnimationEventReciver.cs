
using System;
using UnityEngine;

public class EnemyAnimationEventReceiver : MonoBehaviour
{
    public event Action OnEndAttackEvent;
    public void EndAttack()
    {
        OnEndAttackEvent?.Invoke();
    }
}
