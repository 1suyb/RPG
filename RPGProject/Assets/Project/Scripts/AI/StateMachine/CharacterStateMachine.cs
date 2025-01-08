using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStateMachine : StateMachine
{
    public Character Character { get; private set; }
    
    [field:Header("Controllers")]
    [field:SerializeField] public EntityController Controller { get; private set; }
    [field:SerializeField] public CharacterAnimationController AnimationController { get; private set; }
    [field:SerializeField] public InputEventListenerSO InputEventListener { get; private set; }
    
    public CharacterGroundState Ground { get; private set; }
    public CharacterIdleState Idle { get; private set; }
    public CharacterMoveState Move { get; private set; }
    public CharacterDodgeState Dodge { get; private set; }
    
    public CharacterJumpStartState JumpStart { get; private set; }
    public CharacterUpState Up { get; private set; }
    public CharacterFallState Fall { get; private set; }
    public CharacterJumpEndState JumpEnd { get; private set; }

    [field: Range(0, 2)] public float SpeedModifier { get; set; } = 1f;

    [HideInInspector] public bool IsMove;
    [HideInInspector] public bool IsJump;
    [HideInInspector] public bool IsDodge;
    public bool IsGrounded => Controller.IsGrounded;
    public bool IsAriUp => Controller.IsAriUp;

    
    
    public void Init(Character character)
    {
        Character = character;
        
        Ground = new CharacterGroundState(this);
        Idle = new CharacterIdleState(this);
        Move = new CharacterMoveState(this);
        Dodge = new CharacterDodgeState(this);

        JumpStart = new CharacterJumpStartState(this);
        Up = new CharacterUpState(this);
        Fall = new CharacterFallState(this);
        JumpEnd = new CharacterJumpEndState(this);

        ChangeState(Idle);
    }
}
