using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : LoadedDataBase
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
     /// 실질 옵션ID
     /// </summary>
    public int OptionID;
}

