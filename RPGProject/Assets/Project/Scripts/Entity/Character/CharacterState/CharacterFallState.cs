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