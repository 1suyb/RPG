public class CharacterStat
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

    public float CriticalChance;
    public float CriticalMultiplier;
    
    public float DefensePenetration;
    public float AdditionalDamage;

    public float CoolDownReduction;
    public float TakeDamageReduction;
    public float DealDamageIncrease;
    
    public static CharacterStat operator *(CharacterStat left, CharacterStat right)
    {
        CharacterStat stat = new CharacterStat();
        
        stat.HP = left.HP * right.HP;
        stat.MP = left.MP * right.MP;
        stat.Shield = left.Shield * right.Shield;
        stat.Hunger = left.Hunger * right.Hunger;

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
    
    public static CharacterStat operator +(CharacterStat left, CharacterStat right)
    {
        CharacterStat stat = new CharacterStat();
        
        stat.HP = left.HP + right.HP;
        stat.MP = left.MP + right.MP;
        stat.Shield = left.Shield + right.Shield;
        stat.Hunger = left.Hunger + right.Hunger;

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
    
    public static CharacterStat operator -(CharacterStat left, CharacterStat right)
    {
        CharacterStat stat = new CharacterStat();
        
        stat.HP = left.HP - right.HP;
        stat.MP = left.MP - right.MP;
        stat.Shield = left.Shield - right.Shield;
        stat.Hunger = left.Hunger - right.Hunger;

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
    
    public static CharacterStat operator /(CharacterStat left, CharacterStat right)
        {
            CharacterStat stat = new CharacterStat();
            
            stat.HP = left.HP / right.HP;
            stat.MP = left.MP / right.MP;
            stat.Shield = left.Shield / right.Shield;
            stat.Hunger = left.Hunger / right.Hunger;
    
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