using System.Collections.Generic;
using UnityEngine;

public class ResouceItemInfo : LoadedInfoBase
{
     /// <summary>
     /// 아이템 이름
     /// </summary>
    public string Name;
     /// <summary>
     /// 아이템설명
     /// </summary>
    public string Description;
     /// <summary>
     /// 아이템 타입
     /// </summary>
    public ItemType ItemType;
     /// <summary>
     /// 타입별테이블에서 ID
     /// </summary>
    public int EquipID;
     /// <summary>
     /// 소비테이블 키
     /// </summary>
    public int ComsumeID;
     /// <summary>
     /// 자원 테이블 키
     /// </summary>
    public int ResourceID;
     /// <summary>
     /// 기준가격
     /// </summary>
    public int Price;
     /// <summary>
     /// 판매가능여부
     /// </summary>
    public bool Sell;
     /// <summary>
     /// 버리기 가능 여부
     /// </summary>
    public bool Destory;
}

