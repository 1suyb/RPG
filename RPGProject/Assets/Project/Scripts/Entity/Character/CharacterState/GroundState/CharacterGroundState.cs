using UnityEngine;

public class CharacterGroundState : CharacterBaseState
{
    protected bool IsDodge
    {
        get => _stateMachine.IsDodge;
        set => _stateMachine.IsDodge = value;
    }
    protected bool IsEquipChange
    {
        get => _stateMachine.IsEquipChange;
        set => _stateMachine.IsEquipChange = value;
    }
    public CharacterGroundState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (IsJump)
        {
            _stateMachine.ChangeState(_stateMachine.JumpStart);
        }
        else if (IsDodge)
        {
            if((CharacterBaseState)_stateMachine.CurrentState!=_stateMachine.Dodge)
                _stateMachine.ChangeState(_stateMachine.Dodge);
        }
        else if (IsEquipChange)
        {
            
        }
        else if(IsMove)
        {
            // Walk 상태로 전이
            if((CharacterBaseState)_stateMachine.CurrentState!=_stateMachine.Move)
                _stateMachine.ChangeState(_stateMachine.Move);
        }
        else
        {
            // Idle 상태로 전이
            if((CharacterBaseState)_stateMachine.CurrentState!=_stateMachine.Idle)
                _stateMachine.ChangeState(_stateMachine.Idle);
        }
    }

    protected override void SubscribeEvents()
    {
        base.SubscribeEvents();
        _stateMachine.InputEventListener.OnDodgeInputDown += Dodge;

    }

    protected override void DeSubscribeEvents()
    {
        base.DeSubscribeEvents();
        _stateMachine.InputEventListener.OnDodgeInputDown -= Dodge;
    }

    protected void Dodge()
    {
        IsDodge = true;
    }
}