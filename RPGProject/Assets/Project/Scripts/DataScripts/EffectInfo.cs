using System.Collections.Generic;
using UnityEngine;

public class EffectInfo : LoadedInfoBase
{
     /// <summary>
     /// 설명
     /// </summary>
    public string Description;
     /// <summary>
     /// 회복하는 요소
     /// </summary>
    public EffectType Effect;
     /// <summary>
     /// true-> 백분율 / false -> 절대값
     /// </summary>
    public bool Percentage;
}

