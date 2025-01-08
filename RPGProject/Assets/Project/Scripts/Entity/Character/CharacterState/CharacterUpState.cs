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