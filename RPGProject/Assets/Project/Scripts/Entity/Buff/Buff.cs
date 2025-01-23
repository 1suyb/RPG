using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Buff
{
    public BuffInfo Info { get; private set; }
    public Stat Stat { get; private set; }
    private int _hp;
    private int _mp;
    private int _shield;
    private int _hunger;
    public float Duration { get; private set; }
    public float RemainTime { get; private set; }
    public bool IsDone { get; private set; }

    public Buff(BuffInfo info, Stat stat)
    {
        Info = info;
        Duration = info.Duration;
        RemainTime = Duration;
        IsDone = false;
        SetEffect(stat);
    }
    public void SetEffect(Stat stat)
    {
        StatBuilder statBuilder = new StatBuilder();
        Func<bool, float, float, float> floatadd = (p, a, b) => p? a * (b/100f) : a + b;
        Func<bool, int, int, int> intadd = (p, a, b) => p? (int)(a * (b/100f)) : a + b;
        
        List<int> effectTableID = Info.EffectTableID;
        for(int i = 0 ; i< effectTableID.Count; i++)
        {
            EffectInfo effectInfo = Managers.InfoManager.EffectLoader.GetItem(effectTableID[i]);
            switch (effectInfo.Effect)
            {
                case EffectType.Hp:
                    _hp = effectInfo?.Percentage == true ? (int)(stat.HP * (Info.Value[i] / 100f)) : Info.Value[i];
                    break;
                case EffectType.Mp:
                    _mp = effectInfo?.Percentage == true ? (int)(stat.MP * (Info.Value[i] / 100f)) : Info.Value[i];
                    break;
                case EffectType.Shield:
                    _shield = effectInfo?.Percentage == true ? (int)(stat.Shield * (Info.Value[i] / 100f)) : Info.Value[i];
                    break;
                case EffectType.Hunger:
                    _hunger = effectInfo?.Percentage == true ? (int)(stat.Hunger * (Info.Value[i] / 100f)) : Info.Value[i];
                    break;
                case EffectType.PhysicalAttack:
                    statBuilder.SetPhysicalAttack(intadd(effectInfo.Percentage, stat.PhysicalAttack, Info.Value[i]));
                    break;
                case EffectType.PhysicalDefence:
                    statBuilder.SetPhysicalDefence(intadd(effectInfo.Percentage, stat.PhysicalDefence, Info.Value[i])); 
                    break;
                case EffectType.MagicalAttack:
                    statBuilder.SetMagicalAttack(intadd(effectInfo.Percentage, stat.MagicalAttack, Info.Value[i]));
                    break;
                case EffectType.MagicalDefence:
                    statBuilder.SetMagicalDefence(intadd(effectInfo.Percentage, stat.MagicalDefence, Info.Value[i]));
                    break;
            }
            Stat = statBuilder.Build();
        }
        Stat = stat;
    }
    

    public void UpdateBuff(float deltaTime,IHealable healTarget)
    {
        if (IsDone)
            return;
        RemainTime -= deltaTime;
        healTarget.ReceiveHealing();
        if (RemainTime <= 0)
        {
            IsDone = true;
        }
    }
}
