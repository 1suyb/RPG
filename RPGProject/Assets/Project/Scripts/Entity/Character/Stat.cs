using System;
using UnityEngine;

[Serializable]
public class Stat 
{
    // 속성
    public Stat()
    {
    }

    public Stat(int hp, int mp, int shield, int hunger, int hpPassiveChangeValue, int mpPassiveChangeValue,
        int hungerPassiveChangeValue, int physicalAttack, int magicalAttack, int physicalDefence, int magicalDefence,
        float criticalChance, float criticalMultiplier, float defensePenetration, float additionalDamage,
        float coolDownReduction, float takeDamageReduction, float dealDamageIncrease)
    {
        HP = hp;
        MP = mp;
        Shield = shield;
        Hunger = hunger;
        HpPassiveChangeValue = hpPassiveChangeValue;
        MpPassiveChangeValue = mpPassiveChangeValue;
        HungerPassiveChangeValue = hungerPassiveChangeValue;
        PhysicalAttack = physicalAttack;
        MagicalAttack = magicalAttack;
        PhysicalDefence = physicalDefence;
        MagicalDefence = magicalDefence;
        CriticalChance = criticalChance;
        CriticalMultiplier = criticalMultiplier;
        DefensePenetration = defensePenetration;
        AdditionalDamage = additionalDamage;
        CoolDownReduction = coolDownReduction;
        TakeDamageReduction = takeDamageReduction;
        DealDamageIncrease = dealDamageIncrease;
    }

    public Stat(Stat stat)
    {
        HP = stat.HP;
        MP = stat.MP;
        Shield = stat.Shield;
        Hunger = stat.Hunger;
        HpPassiveChangeValue = stat.HpPassiveChangeValue;
        MpPassiveChangeValue = stat.MpPassiveChangeValue;
        HungerPassiveChangeValue = stat.HungerPassiveChangeValue;
        PhysicalAttack = stat.PhysicalAttack;
        MagicalAttack = stat.MagicalAttack;
        PhysicalDefence = stat.PhysicalDefence;
        MagicalDefence = stat.MagicalDefence;
        CriticalChance = stat.CriticalChance;
        CriticalMultiplier = stat.CriticalMultiplier;
        DefensePenetration = stat.DefensePenetration;
        AdditionalDamage = stat.AdditionalDamage;
        CoolDownReduction = stat.CoolDownReduction;
        TakeDamageReduction = stat.TakeDamageReduction;
        DealDamageIncrease = stat.DealDamageIncrease;
    }
    
    [field:SerializeField] public int HP { get; private set; }
    [field:SerializeField] public int MP{ get; private set; }
    [field:SerializeField] public int Shield{ get; private set; }
    [field:SerializeField] public int Hunger{ get; private set; }
    
    [field:SerializeField] public int HpPassiveChangeValue{ get; private set; }        // 굶주림 시 HP 자연 감소량
    [field:SerializeField] public int MpPassiveChangeValue{ get; private set; }        // MP 자연 회복량
    [field:SerializeField] public int HungerPassiveChangeValue{ get; private set; }    // 굶주림 자연 감소량

    [field:SerializeField] public int PhysicalAttack{ get; private set; }
    [field:SerializeField] public int MagicalAttack{ get; private set; }
    [field:SerializeField] public int PhysicalDefence{ get; private set; }
    [field:SerializeField] public int MagicalDefence{ get; private set; }

    [Tooltip("치명타 확률")]
    [field:SerializeField] public float CriticalChance{ get; private set; }
    [Tooltip("치명타 배율")]
    [field:SerializeField] public float CriticalMultiplier{ get; private set; }
    
    [Tooltip("방어 관통력")]
    [field:SerializeField] public float DefensePenetration{ get; private set; }    // 방어 관통력
    [Tooltip("추가 데미지")]
    [field:SerializeField] public float AdditionalDamage{ get; private set; }      // 추가 데미지

    [Tooltip("쿨다운 감소")]
    [field:SerializeField] public float CoolDownReduction{ get; private set; }     // 쿨다운 감소
    [Tooltip("받는 데미지 감소")]
    [field:SerializeField] public float TakeDamageReduction{ get; private set; }   // 받는 데미지 감소
    [Tooltip("데미지 증가")]
    [field:SerializeField] public float DealDamageIncrease{ get; private set; }    // 주는 데미지 증가
    
    
    
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