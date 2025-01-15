using System;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField]private Stat _baseStat;
    public Stat CurrentStat { get; private set; }
    

    public event Action<Stat> ChangedStat;

    private void Awake()
    {
        CurrentStat = _baseStat;
    }

    public void InitOnCreate(Stat stat)
    {
        _baseStat = stat;
        CurrentStat = _baseStat;
        ChangedStat?.Invoke(CurrentStat);
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