using System;
using UnityEngine;

public class EventListenerBaseSO<T> : ScriptableObject
{
    public event Action<T> OnEventRaised;

    public void RaiseEvent(T parameter)
    {
        OnEventRaised?.Invoke(parameter);
    }
}
