using System;
using Unity.Profiling;
using UnityEngine;

[Serializable]
public class AttackData
{
    public int AnimationNumber;
    
    public int PhysicalPlat;
    public int MagicalPlat;
    public float PhysicalMultiplier;
    public float MagicalMultiplier;

    public float CriticalChance;
    public float CriticalMultiplier;

    public float DefensePenetration;
    public float AdditionalDamage;
    
    public float AttackRange;
    public float AttackSpeed;
    public float AttackCooldown;
    public bool Knockback;

}

[Serializable]
public class DamageData
{
    public int PhysicalDamage;
    public int MagicalDamage;
    
    public float DefensePenetration;
    public bool Knockback;

    public DamageData(int physicalDamage, int magicalDamage, float defensePenetration, bool knockback)
    {
        PhysicalDamage = physicalDamage;
        MagicalDamage = magicalDamage;
        DefensePenetration = defensePenetration;
        Knockback = knockback;
    }
}