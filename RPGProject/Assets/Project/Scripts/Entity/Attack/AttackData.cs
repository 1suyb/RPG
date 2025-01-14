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

