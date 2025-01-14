using System;
using UnityEngine;

[Serializable]
public class Condition
{
    private int _maxCondition;
    private int _currentCondition;
    private int _passiveChangeValue;

    public event Action<float> ChangeCondition;
    public event Action ExhaustCondition;

    public int CurrentCondition
    {
        get => _currentCondition;
        set
        {
            if (_currentCondition != value)
            {
                ChangeCondition?.Invoke((float)_currentCondition/(float)_maxCondition);
            }
            _currentCondition = Mathf.Clamp(value, 0, _maxCondition);
            if (_currentCondition == 0)
            {
                ExhaustCondition?.Invoke();
            }
        }
    }
    
    public Condition(int maxCondition = 100, int passiveChangeValue = 0)
    {
        _maxCondition = maxCondition;
        _currentCondition = _maxCondition;
        _passiveChangeValue = passiveChangeValue;
    }
    
    public void SetMaxCondition(int maxCondition)
    {
        CurrentCondition += maxCondition - _maxCondition;
        _maxCondition = maxCondition;
    }

    public void SetPassiveValue(int passiveValue)
    {
        _passiveChangeValue = passiveValue;
    }

    public void Update()
    {
        _currentCondition += _passiveChangeValue;
    }
}