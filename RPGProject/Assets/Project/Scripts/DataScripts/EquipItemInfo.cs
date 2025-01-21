using System.Collections.Generic;
using UnityEngine;

public class EquipItemInfo : LoadedInfoBase
{
     /// <summary>
     /// 레어도
     /// </summary>
    public Rarity Rarity;
     /// <summary>
     /// 장비 타입
     /// </summary>
    public EquipType EquipmentType;
     /// <summary>
     /// 착용외관 key
     /// </summary>
    public EquipModelingKey ModelingKey;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int MaxHp;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int MaxMp;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int MaxShield;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int MaxHunger;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int PhysicalAttack;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int MagicalAttack;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int PhysicalDefence;
     /// <summary>
     /// 고정상수
     /// </summary>
    public int MagicalDefence;
     /// <summary>
     /// 백분율
     /// </summary>
    public float CriticalChance;
     /// <summary>
     /// 백분율
     /// </summary>
    public float CriticalMultiplier;
     /// <summary>
     /// 착용제한 레벨
     /// </summary>
    public int Level;
}

