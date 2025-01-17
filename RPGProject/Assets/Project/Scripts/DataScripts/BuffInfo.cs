using System.Collections.Generic;
using UnityEngine;

public class BuffInfo : LoadedInfoBase
{
     /// <summary>
     /// 버프 이름
     /// </summary>
    public string Name;
     /// <summary>
     /// 버프효과 설명
     /// </summary>
    public string Description;
     /// <summary>
     /// 효과테이블ID
     /// </summary>
    public List<int> EffectTableID;
     /// <summary>
     /// 증가량
     /// </summary>
    public List<int> Value;
     /// <summary>
     /// 지속시간(초단위)
     /// </summary>
    public int Duration;
}

