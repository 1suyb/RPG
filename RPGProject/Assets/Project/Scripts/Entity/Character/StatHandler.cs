using System;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField] private Stat _baseStat;
    [SerializeField] private Stat _adjustedStat;
    public Stat AdjustedStat => _adjustedStat;
    public Stat CurrentStat { get; private set; }
    
    public event Action<Stat> ChangedStat;

    private void Awake()
    {
        _baseStat = new Stat();
        CurrentStat = _baseStat;
    }

    public void InitOnCreate(Stat stat)
    {
        _baseStat = stat;
        _adjustedStat = _baseStat;
        CurrentStat = new Stat(_adjustedStat);
        ChangedStat?.Invoke(CurrentStat);
    }

    public void AddAdjustStat(Stat stat)
    {
        _adjustedStat += stat;
        CurrentStat = _baseStat + _adjustedStat;
    }
    public void SubtractAdjustStat(Stat stat)
    {
        _adjustedStat -= stat;
        CurrentStat = _baseStat + _adjustedStat;
    }
    
    public void MultiplyStat(Stat stat, StatHandleType type = StatHandleType.BaseMultiply)
    {
        if (type == StatHandleType.FinalMultiply)
        {
            CurrentStat *= stat;
        }
        else
        {
            CurrentStat += _baseStat * stat;
        }
        ChangedStat?.Invoke(stat);
    }
    
    public void DivideStat(Stat stat, StatHandleType type = StatHandleType.BaseMultiply)
    {
        if (type == StatHandleType.FinalMultiply)
        {
            CurrentStat /= stat;
        }
        else
        {
            CurrentStat /= _baseStat * stat;
        }
        ChangedStat?.Invoke(stat);
    }

    public void AddStat(Stat stat, StatHandleType type = StatHandleType.Add)
    {
        CurrentStat += stat;
        ChangedStat?.Invoke(stat);
    }
    
    public void SubtractStat(Stat stat, StatHandleType type = StatHandleType.Add)
    {
        CurrentStat -= stat;
        ChangedStat?.Invoke(stat);
    }
    
}