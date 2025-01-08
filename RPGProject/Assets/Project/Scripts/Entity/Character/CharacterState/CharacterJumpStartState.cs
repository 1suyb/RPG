public class CharacterJumpStartState : CharacterAirState
{
    private string _jumpStartAnimTag;
    
    public CharacterJumpStartState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _jumpStartAnimTag = StateMachine.AnimationController.JumpStartTag;
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