using UnityEngine;

public class CharacterBaseState : IState
{
    protected CharacterStateMachine StateMachine;

    protected float SpeedModifier
    {
        get => StateMachine.SpeedModifier;
        set => StateMachine.SpeedModifier = value;
    }

    protected bool IsMove
    {
        get => StateMachine.IsMove;
        set => StateMachine.IsMove = value;
    }

    protected bool IsJump
    {
        get => StateMachine.IsJump;
        set => StateMachine.IsJump = value;
    }
    protected Vector3 LookDir => StateMachine.InputEventListener.LookDir;
    protected Vector3 MoveDir => StateMachine.InputEventListener.MoveDir;
    protected bool IsGrounded => StateMachine.IsGrounded;
    protected bool IsAriUp => StateMachine.IsAriUp;

    protected int MoveZAnimHash => StateMachine.AnimData.MoveZ.Hash;
    protected int MoveXAnimHash => StateMachine.AnimData.MoveX.Hash;
    
    public CharacterBaseState(CharacterStateMachine stateMachine)
    {
        StateMachine = stateMachine;
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
        StateMachine.InputEventListener.OnStartMove += StartMove;
        StateMachine.InputEventListener.OnStopMove += StopMove;
        StateMachine.InputEventListener.OnJumpInputUp += Jump;

    }

    protected virtual void DeSubscribeEvents()
    {
        StateMachine.InputEventListener.OnStartMove -= StartMove;
        StateMachine.InputEventListener.OnStopMove -= StopMove;
        StateMachine.InputEventListener.OnJumpInputUp -= Jump;
    }

    protected void StartMove()
    {
        IsMove = true;
        StartAnimation(StateMachine.AnimData.IsMove.Hash);
        
    }
    protected void StopMove()
    {
        IsMove = false;
        StopAnimation(StateMachine.AnimData.IsMove.Hash);
    }
    protected void Jump()
    {
        IsJump = true;
    }
    

    protected virtual void Move()
    {
        Quaternion rotateVec = EntityController.RorateVector(LookDir);
        Vector3 animDir = rotateVec * MoveDir;
        StateMachine.AnimationController.SetFloat(MoveZAnimHash, animDir.z);
        StateMachine.AnimationController.SetFloat(MoveXAnimHash, animDir.x);
        StateMachine.Controller.LookAt(LookDir);
        StateMachine.Controller.Move(MoveDir,SpeedModifier);
    }

    protected void StartAnimation(int hash)
    {
        StateMachine.AnimationController.SetBool(hash,true);
    }

    protected void StopAnimation(int hash)
    {
        StateMachine.AnimationController.SetBool(hash,false);
    }
    
}
