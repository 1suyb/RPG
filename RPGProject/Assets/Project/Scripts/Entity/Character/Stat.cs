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
    public int HP { get; private set; }
    public int MP{ get; private set; }
    public int Shield{ get; private set; }
    public int Hunger{ get; private set; }
    
    public int HpPassiveChangeValue{ get; private set; }        // 굶주림 시 HP 자연 감소량
    public int MpPassiveChangeValue{ get; private set; }        // MP 자연 회복량
    public int HungerPassiveChangeValue{ get; private set; }    // 굶주림 자연 감소량

    public int PhysicalAttack{ get; private set; }
    public int MagicalAttack{ get; private set; }
    public int PhysicalDefence{ get; private set; }
    public int MagicalDefence{ get; private set; }

    [Tooltip("치명타 확률")]
    public float CriticalChance{ get; private set; }
    [Tooltip("치명타 배율")]
    public float CriticalMultiplier{ get; private set; }
    
    [Tooltip("방어 관통력")]
    public float DefensePenetration{ get; private set; }    // 방어 관통력
    [Tooltip("추가 데미지")]
    public float AdditionalDamage{ get; private set; }      // 추가 데미지

    [Tooltip("쿨다운 감소")]
    public float CoolDownReduction{ get; private set; }     // 쿨다운 감소
    [Tooltip("받는 데미지 감소")]
    public float TakeDamageReduction{ get; private set; }   // 받는 데미지 감소
    [Tooltip("데미지 증가")]
    public float DealDamageIncrease{ get; private set; }    // 주는 데미지 증가
    
    
    
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

public class StatBuilder
{
    private int _hp;
    private int _mp;
    private int _shield;
    private int _hunger;

    private int _hpPassiveChangeValue;
    private int _mpPassiveChangeValue;
    private int _hungerPassiveChangeValue;

    private int _physicalAttack;
    private int _magicalAttack;
    private int _physicalDefence;
    private int _magicalDefence;

    private float _criticalChance;
    private float _criticalMultiplier;
    private float _defensePenetration;
    private float _additionalDamage;
    private float _coolDownReduction;
    private float _takeDamageReduction;
    private float _dealDamageIncrease;

    public StatBuilder SetHP(int hp)
    {
        _hp = hp;
        return this;
    }

    public StatBuilder SetMP(int mp)
    {
        _mp = mp;
        return this;
    }

    public StatBuilder SetShield(int shield)
    {
        _shield = shield;
        return this;
    }

    public StatBuilder SetHunger(int hunger)
    {
        _hunger = hunger;
        return this;
    }

    public StatBuilder SetHpPassiveChangeValue(int value)
    {
        _hpPassiveChangeValue = value;
        return this;
    }

    public StatBuilder SetMpPassiveChangeValue(int value)
    {
        _mpPassiveChangeValue = value;
        return this;
    }

    public StatBuilder SetHungerPassiveChangeValue(int value)
    {
        _hungerPassiveChangeValue = value;
        return this;
    }

    public StatBuilder SetPhysicalAttack(int value)
    {
        _physicalAttack = value;
        return this;
    }

    public StatBuilder SetMagicalAttack(int value)
    {
        _magicalAttack = value;
        return this;
    }

    public StatBuilder SetPhysicalDefence(int value)
    {
        _physicalDefence = value;
        return this;
    }

    public StatBuilder SetMagicalDefence(int value)
    {
        _magicalDefence = value;
        return this;
    }

    public StatBuilder SetCriticalChance(float value)
    {
        _criticalChance = value;
        return this;
    }

    public StatBuilder SetCriticalMultiplier(float value)
    {
        _criticalMultiplier = value;
        return this;
    }

    public StatBuilder SetDefensePenetration(float value)
    {
        _defensePenetration = value;
        return this;
    }

    public StatBuilder SetAdditionalDamage(float value)
    {
        _additionalDamage = value;
        return this;
    }

    public StatBuilder SetCoolDownReduction(float value)
    {
        _coolDownReduction = value;
        return this;
    }

    public StatBuilder SetTakeDamageReduction(float value)
    {
        _takeDamageReduction = value;
        return this;
    }

    public StatBuilder SetDealDamageIncrease(float value)
    {
        _dealDamageIncrease = value;
        return this;
    }

    public Stat Build()
    {
        return new Stat(
            _hp, 
            _mp, 
            _shield, 
            _hunger, 
            _hpPassiveChangeValue, 
            _mpPassiveChangeValue, 
            _hungerPassiveChangeValue, 
            _physicalAttack, 
            _magicalAttack, 
            _physicalDefence, 
            _magicalDefence, 
            _criticalChance, 
            _criticalMultiplier, 
            _defensePenetration, 
            _additionalDamage, 
            _coolDownReduction, 
            _takeDamageReduction, 
            _dealDamageIncrease
        );
    }
}
