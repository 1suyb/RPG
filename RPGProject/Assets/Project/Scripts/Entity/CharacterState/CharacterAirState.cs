using Unity.Profiling;

public class CharacterAirState : CharacterBaseState
{
    protected int JumpAnimHash;
    public CharacterAirState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        JumpAnimHash = stateMachine.AnimData.IsAir.Hash;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (!IsJump)
        {
            StateMachine.ChangeState(StateMachine.Ground);
        }
    }
}

public class CharacterJumpStartState : CharacterAirState
{
    private string _jumpStartAnimTag;
    
    public CharacterJumpStartState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _jumpStartAnimTag = StateMachine.AnimData.TagJumpStart.Tag;
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(JumpAnimHash);
    }

    public override void Update()
    {
        base.Update();
        if (StateMachine.AnimationController.IsPlayAnimation(_jumpStartAnimTag) >= 1f)
        {
            StateMachine.Controller.Jump(0.5f);
            StateMachine.ChangeState(StateMachine.Up);
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
            StateMachine.ChangeState(StateMachine.Fall);
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
            StateMachine.ChangeState(StateMachine.JumpEnd);
        }
    }
}

public class CharacterJumpEndState : CharacterAirState
{
    private float _preSpeed;
    private string _jumpEndAnimTag;
    public CharacterJumpEndState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _jumpEndAnimTag = stateMachine.AnimData.TagJumpEnd.Tag;
    }

    public override void Enter()
    {
        base.Enter();
        StopAnimation(JumpAnimHash);
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
        if (StateMachine.AnimationController.IsPlayAnimation(_jumpEndAnimTag) >= 1f)
        {
            IsJump = false;
        }
        
    }
}