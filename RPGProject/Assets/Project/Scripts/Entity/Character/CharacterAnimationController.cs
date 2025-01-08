using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : EntityAnimationController
{
    [field:Header("Parameters")]
    [field:SerializeField] public string IsMove { get; private set; }
    [field:SerializeField] public string IsJump { get; private set; }
    [field:SerializeField] public string IsDodge { get; private set; }
    [field:SerializeField] public string IsFall { get; private set; }
    [field:SerializeField] public string IsDie { get; private set; }
    [field:SerializeField] public string MoveX { get; private set; }
    [field:SerializeField] public string MoveZ { get; private set; }
    
    [field:Header("Tag")]
    [field:SerializeField] public string DodgeTag { get; private set; }
    [field:SerializeField] public string JumpStartTag { get; private set; }
    [field:SerializeField] public string JumpEndTag { get; private set; }
    
    public int IsMoveHash { get; private set; }
    public int IsJumpHash { get; private set; }
    public int IsDodgeHash { get; private set; }
    public int IsFallHash { get; private set; }
    public int IsDieHash { get; private set; }
    public int MoveXHash { get; private set; }
    public int MoveZHash { get; private set; }

    private void Awake()
    {
        IsMoveHash = Animator.StringToHash(IsMove);
        IsJumpHash = Animator.StringToHash(IsJump);
        IsDodgeHash = Animator.StringToHash(IsDodge);
        IsFallHash = Animator.StringToHash(IsFall);
        IsDieHash = Animator.StringToHash(IsDie);
        MoveXHash = Animator.StringToHash(MoveX);
        MoveZHash = Animator.StringToHash(MoveZ);
    }
}
