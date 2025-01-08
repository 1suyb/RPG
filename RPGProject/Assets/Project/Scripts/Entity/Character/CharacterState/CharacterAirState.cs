public class CharacterAirState : CharacterBaseState
{
    protected int JumpAnimHash;
    public CharacterAirState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        JumpAnimHash = stateMachine.AnimationController.IsJumpHash;
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