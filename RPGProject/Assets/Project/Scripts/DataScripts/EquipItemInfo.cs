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
     /// 스텟 옵션키
     /// </summary>
    public List<StatType> StatEffectID;
     /// <summary>
     /// 효과 최소 값
     /// </summary>
    public List<int> MinValue;
     /// <summary>
     /// 효과 최대값
     /// </summary>
    public List<int> MaxValue;
     /// <summary>
     /// 옵션 개수
     /// </summary>
    public int OptionCount;
     /// <summary>
     /// 옵션 풀
     /// </summary>
    public int OptionPoolID;
     /// <summary>
     /// 착용제한 레벨
     /// </summary>
    public int Level;
}

