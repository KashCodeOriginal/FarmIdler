using KasherOriginal.Factories.UIFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameplayState : State<GameInstance>
    {
        public GameplayState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }

        private readonly IUIFactory _uiFactory;

        public override void Enter()
        {
            _uiFactory.DestroyGameLoadingScreen();
        }
    }
}