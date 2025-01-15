using System;
using UnityEngine;

public class Condition
{
    private int _maxValue;
    private int _currentValue;
    private int _passiveChangeValue;

    public event Action<float> ChangeCondition;
    public event Action ExhaustCondition;

    public int CurrentValue
    {
        get => _currentValue;
        set
        {
            if (_currentValue != value)
            {
                ChangeCondition?.Invoke((float)_currentValue/(float)_maxValue);
            }
            _currentValue = Mathf.Clamp(value, 0, _maxValue);
            if (_currentValue == 0)
            {
                ExhaustCondition?.Invoke();
            }
        }
    }
    
    public Condition(int maxValue = 100, int passiveChangeValue = 0)
    {
        _maxValue = maxValue;
        _currentValue = _maxValue;
        _passiveChangeValue = passiveChangeValue;
    }
    
    public void SetMaxCondition(int maxCondition)
    {
        CurrentValue += maxCondition - _maxValue;
        _maxValue = maxCondition;
    }

    public void SetPassiveValue(int passiveValue)
    {
        _passiveChangeValue = passiveValue;
    }

    public void Update()
    {
        _currentValue += _passiveChangeValue;
    }
}