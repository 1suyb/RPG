using System;
using UnityEngine;

[Serializable]
public class Stat 
{
    // 속성
    public int HP;
    public int MP;
    public int Shield;
    public int Hunger;
    
    public int HpPassiveChangeValue;        // 굶주림 시 HP 자연 감소량
    public int MpPassiveChangeValue;        // MP 자연 회복량
    public int HungerPassiveChangeValue;    // 굶주림 자연 감소량

    public int PhysicalAttack;
    public int MagicalAttack;
    public int PhysicalDefence;
    public int MagicalDefence;

    [Tooltip("치명타 확률")]
    public float CriticalChance;
    [Tooltip("치명타 배율")]
    public float CriticalMultiplier;
    
    [Tooltip("방어 관통력")]
    public float DefensePenetration;    // 방어 관통력
    [Tooltip("추가 데미지")]
    public float AdditionalDamage;      // 추가 데미지

    [Tooltip("쿨다운 감소")]
    public float CoolDownReduction;     // 쿨다운 감소
    [Tooltip("받는 데미지 감소")]
    public float TakeDamageReduction;   // 받는 데미지 감소
    [Tooltip("데미지 증가")]
    public float DealDamageIncrease;    // 주는 데미지 증가
    
    public static Stat operator *(Stat left, Stat right)
    {
        Stat stat = new Stat();
        
        stat.HP = left.HP * right.HP;
        stat.MP = left.MP * right.MP;
        stat.Shield = left.Shield * right.Shield;
        stat.Hunger = left.Hunger * right.Hunger;
        
        stat.HpPassiveChangeValue = left.HpPassiveChangeValue * right.HpPassiveChangeValue;
        stat.MpPassiveChangeValue = left.MpPassiveChangeValue * right.MpPassiveChangeValue;
        stat.HungerPassiveChangeValue = left.HungerPassiveChangeValue * right.HungerPassiveChangeValue;

        stat.PhysicalAttack = left.PhysicalAttack * right.PhysicalAttack;
        stat.MagicalAttack = left.MagicalAttack * right.MagicalAttack;
        stat.PhysicalDefence = left.PhysicalDefence * right.PhysicalDefence;
        stat.MagicalDefence = left.MagicalDefence * right.MagicalDefence;

        stat.CriticalChance = left.CriticalChance * right.CriticalChance;
        stat.CriticalMultiplier = left.CriticalMultiplier * right.CriticalMultiplier;
        
        stat.DefensePenetration = left.DefensePenetration * right.DefensePenetration;
        stat.AdditionalDamage = left.AdditionalDamage * right.AdditionalDamage;

        stat.CoolDownReduction = left.CoolDownReduction * right.CoolDownReduction;
        stat.TakeDamageReduction = left.TakeDamageReduction * right.TakeDamageReduction;
        stat.DealDamageIncrease = left.DealDamageIncrease * right.DealDamageIncrease;

        return stat;
    }
    
    public static Stat operator +(Stat left, Stat right)
    {
        Stat stat = new Stat();
        
        stat.HP = left.HP + right.HP;
        stat.MP = left.MP + right.MP;
        stat.Shield = left.Shield + right.Shield;
        stat.Hunger = left.Hunger + right.Hunger;
        
        stat.HpPassiveChangeValue = left.HpPassiveChangeValue + right.HpPassiveChangeValue;
        stat.MpPassiveChangeValue = left.MpPassiveChangeValue + right.MpPassiveChangeValue;
        stat.HungerPassiveChangeValue = left.HungerPassiveChangeValue + right.HungerPassiveChangeValue;

        stat.PhysicalAttack = left.PhysicalAttack + right.PhysicalAttack;
        stat.MagicalAttack = left.MagicalAttack + right.MagicalAttack;
        stat.PhysicalDefence = left.PhysicalDefence + right.PhysicalDefence;
        stat.MagicalDefence = left.MagicalDefence + right.MagicalDefence;

        stat.CriticalChance = left.CriticalChance + right.CriticalChance;
        stat.CriticalMultiplier = left.CriticalMultiplier + right.CriticalMultiplier;

        stat.CoolDownReduction = left.CoolDownReduction + right.CoolDownReduction;
        stat.TakeDamageReduction = left.TakeDamageReduction + right.TakeDamageReduction;
        stat.DealDamageIncrease = left.DealDamageIncrease + right.DealDamageIncrease;

        return stat;
    }
    
    public static Stat operator -(Stat left, Stat right)
    {
        Stat stat = new Stat();
        
        stat.HP = left.HP - right.HP;
        stat.MP = left.MP - right.MP;
        stat.Shield = left.Shield - right.Shield;
        stat.Hunger = left.Hunger - right.Hunger;
        
        stat.HpPassiveChangeValue = left.HpPassiveChangeValue - right.HpPassiveChangeValue;
        stat.MpPassiveChangeValue = left.MpPassiveChangeValue - right.MpPassiveChangeValue;
        stat.HungerPassiveChangeValue = left.HungerPassiveChangeValue - right.HungerPassiveChangeValue;

        stat.PhysicalAttack = left.PhysicalAttack - right.PhysicalAttack;
        stat.MagicalAttack = left.MagicalAttack - right.MagicalAttack;
        stat.PhysicalDefence = left.PhysicalDefence - right.PhysicalDefence;
        stat.MagicalDefence = left.MagicalDefence - right.MagicalDefence;

        stat.CriticalChance = left.CriticalChance - right.CriticalChance;
        stat.CriticalMultiplier = left.CriticalMultiplier - right.CriticalMultiplier;

        stat.CoolDownReduction = left.CoolDownReduction - right.CoolDownReduction;
        stat.TakeDamageReduction = left.TakeDamageReduction - right.TakeDamageReduction;
        stat.DealDamageIncrease = left.DealDamageIncrease - right.DealDamageIncrease;

        return stat;
    }
    
    public static Stat operator /(Stat left, Stat right)
        {
            Stat stat = new Stat();
            
            stat.HP = left.HP / right.HP;
            stat.MP = left.MP / right.MP;
            stat.Shield = left.Shield / right.Shield;
            stat.Hunger = left.Hunger / right.Hunger;
            
            stat.HpPassiveChangeValue = left.HpPassiveChangeValue / right.HpPassiveChangeValue;
            stat.MpPassiveChangeValue = left.MpPassiveChangeValue / right.MpPassiveChangeValue;
            stat.HungerPassiveChangeValue = left.HungerPassiveChangeValue / right.HungerPassiveChangeValue;
    
            stat.PhysicalAttack = left.PhysicalAttack / right.PhysicalAttack;
            stat.MagicalAttack = left.MagicalAttack / right.MagicalAttack;
            stat.PhysicalDefence = left.PhysicalDefence / right.PhysicalDefence;
            stat.MagicalDefence = left.MagicalDefence / right.MagicalDefence;
    
            stat.CriticalChance = left.CriticalChance / right.CriticalChance;
            stat.CriticalMultiplier = left.CriticalMultiplier / right.CriticalMultiplier;
    
            stat.CoolDownReduction = left.CoolDownReduction / right.CoolDownReduction;
            stat.TakeDamageReduction = left.TakeDamageReduction / right.TakeDamageReduction;
            stat.DealDamageIncrease = left.DealDamageIncrease / right.DealDamageIncrease;
    
            return stat;
        }
}

public enum StatHandleType
{
    Add,
    BaseMultiply,
    FinalMultiply,
}