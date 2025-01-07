public class CharacterAirState : CharacterBaseState
{
    public CharacterAirState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Update()
    {
        base.Update();
        if (IsGrounded)
        {
            // Ground 상태로 전이
        }
        if(IsAriUp)
        {
            // Jump 상태로 전이
        }
        else
        {
            // fall 상태로 전이
        }
        
    }
}