using System;
using Unity.VisualScripting;
using UnityEngine;

public class Condition
{
    private int _maxValue;
    private int _currentValue;
    private int _passiveChangeValue;

    public Action<float> OnChangeCondition;
    public Action OnExhaustCondition;
    public Action OnConsumeCondition;
    public Action OnRecoveryCondition;
    public int CurrentValue
    {
        get => _currentValue;
        set
        {
            if (_currentValue != value)
            {
                OnChangeCondition?.Invoke((float)_currentValue/(float)_maxValue);
                if (_currentValue < value)
                {
                    OnRecoveryCondition?.Invoke();
                }
                else
                {
                    OnConsumeCondition?.Invoke();
                }
            }
            _currentValue = Mathf.Clamp(value, 0, _maxValue);
            if (_currentValue == 0)
            {
                OnExhaustCondition?.Invoke();
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