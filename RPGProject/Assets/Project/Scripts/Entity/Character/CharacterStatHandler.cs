using System;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    private CharacterStat _baseStat;
    public CharacterStat CurrentStat { get; private set; }
    

    public event Action<CharacterStat> ChangedStat;

    public void Init(CharacterStat stat)
    {
        _baseStat = stat;
        CurrentStat = _baseStat;
        ChangedStat?.Invoke(CurrentStat);
    }

    public void MultiplyStat(CharacterStat stat, StatHandleType type = StatHandleType.BaseMultiply)
    {
        if (type == StatHandleType.FinalMultiply)
        {
            CurrentStat *= stat;
        }
        else
        {
            CurrentStat += _baseStat * stat;
        }
        ChangedStat?.Invoke(CurrentStat);
    }
    
    public void DivideStat(CharacterStat stat, StatHandleType type = StatHandleType.BaseMultiply)
    {
        if (type == StatHandleType.FinalMultiply)
        {
            CurrentStat /= stat;
        }
        else
        {
            CurrentStat /= _baseStat * stat;
        }
        ChangedStat?.Invoke(CurrentStat);
    }

    public void AddStat(CharacterStat stat, StatHandleType type = StatHandleType.Add)
    {
        CurrentStat += stat;
        ChangedStat?.Invoke(CurrentStat);
    }
    
    public void SubtractStat(CharacterStat stat, StatHandleType type = StatHandleType.Add)
    {
        CurrentStat -= stat;
        ChangedStat?.Invoke(CurrentStat);
    }
    
}