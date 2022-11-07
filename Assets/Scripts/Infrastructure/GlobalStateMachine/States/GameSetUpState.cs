namespace KasherOriginal.GlobalStateMachine
{
    public class GameSetUpState : State<GameInstance>
    {
        public GameSetUpState(GameInstance context) : base(context) { }

        public override void Enter()
        {
            Context.StateMachine.SwitchState<GameplayState>();
        }
    }
}