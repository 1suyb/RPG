using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : EntityAnimationController
{
    [field:SerializeField] public AnimationDataSO IsMove { get; private set; }
    [field:SerializeField] public AnimationDataSO IsAir { get; private set; }
    [field:SerializeField] public AnimationDataSO IsDodge { get; private set; }
    [field:SerializeField] public AnimationDataSO IsFall { get; private set; }
    [field:SerializeField] public AnimationDataSO MoveDir { get; private set; }
    [field:SerializeField] public AnimationDataSO IsDie { get; private set; }
}
