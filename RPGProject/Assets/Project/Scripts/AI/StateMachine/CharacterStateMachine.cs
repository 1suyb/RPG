using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    public Character Character { get; private set; }
    
    [field:Header("Controllers")]
    [field:SerializeField] public EntityController Controller { get; private set; }
    [field:SerializeField] public CharacterAnimationController AnimationController { get; private set; }
    [field:SerializeField] public InputEventListenerSO InputEventListener { get; private set; }
    

    [field: Range(0, 2)] public float SpeedModifier { get; set; } = 1f;

    [HideInInspector] public bool IsMove;
    [HideInInspector] public bool IsJump;
    [HideInInspector] public bool IsDodge;
    [HideInInspector] public bool IsEquipped;
    [HideInInspector] public bool IsEquipChange;
    [HideInInspector] public bool IsAttack;
    [HideInInspector] public int AttackNumber;
    public bool IsGrounded => Controller.IsGrounded;
    public bool IsAriUp => Controller.IsAriUp;

    public CharacterGroundState Ground { get; private set; }
    public CharacterIdleState Idle { get; private set; }
    public CharacterMoveState Move { get; private set; }
    public CharacterDodgeState Dodge { get; private set; }
    public CharacterEquipChangeState EquipChange { get; private set; }
    public CharacterAttackState Attack { get; private set; }
    
    public CharacterJumpStartState JumpStart { get; private set; }
    public CharacterUpState Up { get; private set; }
    public CharacterFallState Fall { get; private set; }
    public CharacterJumpEndState JumpEnd { get; private set; }
    
    
    public void Init(Character character)
    {
        Character = character;
        
        Ground = new CharacterGroundState(this);
        Idle = new CharacterIdleState(this);
        Move = new CharacterMoveState(this);
        Dodge = new CharacterDodgeState(this);
        EquipChange = new CharacterEquipChangeState(this);
        Attack = new CharacterAttackState(this);
        
        JumpStart = new CharacterJumpStartState(this);
        Up = new CharacterUpState(this);
        Fall = new CharacterFallState(this);
        JumpEnd = new CharacterJumpEndState(this);
        
        Activate();
    }
    
    public void Activate()
    {
        IsMove = false;
        IsJump = false;
        IsDodge = false;
        
        ChangeState(Idle);
    }
}
