using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    public Character Character { get; private set; }
    
    [field:Header("Controllers")]
    [field:SerializeField] public EntityController Controller { get; private set; }
    [field:SerializeField] public EntityAnimationController AnimationController { get; private set; }
    [field:SerializeField] public InputEventListenerSO InputEventListener { get; private set; }
    
    [field:Header("AnimationData")]
    [field:SerializeField] public CharacterAnimationDataSO AnimData { get; private set; }

    
    public CharacterIdleState Idle { get; private set; }
    public CharacterMoveState Move { get; private set; }
    public CharacterDodgeState Dodge { get; private set; }
    public CharacterBaseState Jump { get; private set; }
    
    [field:Range(0,2)]public float SpeedModifier { get; set; }
    
    public bool IsMove { get; set; }
    public bool IsGrounded => Controller.IsGrounded;
    public bool IsAriUp => Controller.IsAriUp;
    
    public bool IsDodge { get; set; }
    
    public void Init(Character character)
    {
        Character = character;
        Idle = new CharacterIdleState(this);
        Move = new CharacterMoveState(this);
        Dodge = new CharacterDodgeState(this);
        //Jump.Init(this);
        ChangeState(Idle);
    }
}
