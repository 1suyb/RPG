using UnityEngine;

public class AttackHandler
{
    private Stat _attackerStat;
    private AttackData _attackData;
    
    private float _physicalDamage;
    private float _magicalDamage;
    
    public AttackHandler(Stat attackerStat, AttackData attackData)
    {
        _attackerStat = attackerStat;
        _attackData = attackData;
        
        _physicalDamage = (_attackerStat.PhysicalAttack + _attackData.PhysicalPlat)*
                          (_attackData.PhysicalMultiplier/100f);
        _magicalDamage = (_attackerStat.MagicalAttack + _attackData.MagicalPlat) *
                         (_attackData.MagicalMultiplier / 100f);
        
        float additionalDamage = (_attackData.AdditionalDamage + _attackerStat.AdditionalDamage)/100f;
        _physicalDamage = (int)(_physicalDamage * (1 + additionalDamage) );
        _magicalDamage = (int)(_magicalDamage * (1 + additionalDamage));
        
        float random = Random.Range(0f, 100f);
        float criticalChance = _attackData.CriticalChance + _attackerStat.CriticalChance;
        float criticalMultiplier = (_attackData.CriticalMultiplier + _attackerStat.CriticalMultiplier)/100f;
        if(random<criticalChance)
        {
            _physicalDamage = (_physicalDamage * (1 + additionalDamage) * (criticalMultiplier));
            _magicalDamage = (_magicalDamage * (1 + additionalDamage) * (criticalMultiplier));
        }
    }

    public int CalculateDamage(Stat targetStat)
    {
        float defensePenetration = _attackData.DefensePenetration + _attackerStat.DefensePenetration;
        defensePenetration = defensePenetration / 100f;
        _physicalDamage = _physicalDamage - (targetStat.PhysicalDefence*(1-defensePenetration));
        _magicalDamage = _magicalDamage - (targetStat.MagicalDefence*(1-defensePenetration));
        
        float totalDamage = _magicalDamage + _physicalDamage;
        
        float takeDamageReduction = targetStat.TakeDamageReduction/100f;
        totalDamage = totalDamage*(1-takeDamageReduction);
        
        float dealDamageIncrease = _attackerStat.DealDamageIncrease/100f;
        totalDamage = totalDamage*(1+dealDamageIncrease);
        
        return (int)totalDamage;
    }
}