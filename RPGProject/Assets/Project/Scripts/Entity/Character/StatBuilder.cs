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