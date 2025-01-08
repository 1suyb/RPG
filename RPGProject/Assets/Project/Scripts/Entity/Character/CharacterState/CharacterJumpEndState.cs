public class CharacterJumpEndState : CharacterAirState
{
    private float _preSpeed;
    private string _jumpEndAnimTag;
    public CharacterJumpEndState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _jumpEndAnimTag = stateMachine.AnimationController.JumpEndTag;
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