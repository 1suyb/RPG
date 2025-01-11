using UnityEngine;

public class CharacterBaseState : IState
{
    protected CharacterStateMachine _stateMachine;
    protected CharacterAnimationController _animationController => _stateMachine.AnimationController;
    

    protected float SpeedModifier
    {
        get => _stateMachine.SpeedModifier;
        set => _stateMachine.SpeedModifier = value;
    }

    protected bool IsMove
    {
        get => _stateMachine.IsMove;
        set => _stateMachine.IsMove = value;
    }

    protected bool IsJump
    {
        get => _stateMachine.IsJump;
        set => _stateMachine.IsJump = value;
    }

    protected bool IsAttack
    {
        get => _stateMachine.IsAttack;
        set => _stateMachine.IsAttack = value;
    }

    protected int AttackNumber
    {
        get => _stateMachine.AttackNumber;
        set => _stateMachine.AttackNumber = value;
    }
    
    protected Vector3 LookDir => _stateMachine.InputEventListener.LookDir;
    protected Vector3 MoveDir => _stateMachine.InputEventListener.MoveDir;
    protected bool IsGrounded => _stateMachine.IsGrounded;
    
    
    public CharacterBaseState(CharacterStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public virtual void Enter()
    {
        SubscribeEvents();
    }

    public virtual void Exit()
    {
        DeSubscribeEvents();
    }

    public virtual void Update()
    {
        Move();
    }
    protected virtual void SubscribeEvents()
    {
        _stateMachine.InputEventListener.OnStartMove += StartMove;
        _stateMachine.InputEventListener.OnStopMove += StopMove;
        _stateMachine.InputEventListener.OnJumpInputUp += Jump;
    }

    protected virtual void DeSubscribeEvents()
    {
        _stateMachine.InputEventListener.OnStartMove -= StartMove;
        _stateMachine.InputEventListener.OnStopMove -= StopMove;
        _stateMachine.InputEventListener.OnJumpInputUp -= Jump;
    }

    protected void StartMove()
    {
        IsMove = true;
        _animationController.StartMove();
    }
    
    protected void StopMove()
    {
        IsMove = false;
        _animationController.StopMove();
    }
    
    protected void Jump()
    {
        IsJump = true;
    }
    

    protected virtual void Move()
    {
        Quaternion rotateVec = EntityController.RotateVector(LookDir);
        Vector3 animDir = rotateVec * MoveDir;
        _animationController.SetMoveDir(animDir.z, animDir.x);
        _stateMachine.Controller.LookAt(LookDir);
        _stateMachine.Controller.Move(MoveDir,SpeedModifier);
    }
    
}
