public class CharacterAirState : CharacterBaseState
{
    protected bool IsAriUp => _stateMachine.IsAriUp;
    
    public CharacterAirState(CharacterStateMachine stateMachine) : base(stateMachine)
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
        if (!IsJump)
        {
            _stateMachine.ChangeState(_stateMachine.Ground);
        }
    }
}

public class CharacterJumpStartState : CharacterAirState
{
    private readonly string _jumpStartTag;
    public CharacterJumpStartState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _jumpStartTag = _animationController.JumpStartTag;
    }

    public override void Enter()
    {
        base.Enter();
        _animationController.StartJump();
    }

    public override void Update()
    {
        base.Update();
        if (_animationController.IsPlayAnimation(_jumpStartTag)>=1f)
        {
            _stateMachine.Controller.Jump(0.5f);
            _stateMachine.ChangeState(_stateMachine.Up);
        }
    }
}

public class CharacterUpState : CharacterAirState
{
    public CharacterUpState(CharacterStateMachine stateMachine) : base(stateMachine)
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
        if (!IsAriUp)
        {
            // Fall상태로 전환
            _stateMachine.ChangeState(_stateMachine.Fall);
        }
        
    }
}

public class CharacterFallState : CharacterAirState
{
    
    public CharacterFallState(CharacterStateMachine stateMachine) : base(stateMachine)
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
        if (IsGrounded)
        {
            _stateMachine.ChangeState(_stateMachine.JumpEnd);
        }
    }
}

public class CharacterJumpEndState : CharacterAirState
{
    private float _preSpeed;
    private readonly string _jumpEndTag;
    public CharacterJumpEndState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _jumpEndTag = _animationController.JumpEndTag;
    }

    public override void Enter()
    {
        base.Enter();
        _animationController.StopJump();
        _preSpeed = SpeedModifier;
        SpeedModifier = 0f;
    }

    public override void Exit()
    {
        base.Exit();
        SpeedModifier = _preSpeed;
    }

    public override void Update()
    {
        base.Update();
        if (_animationController.IsPlayAnimation(_jumpEndTag) >= 1f)
        {
            IsJump = false;
        }
    }
}
