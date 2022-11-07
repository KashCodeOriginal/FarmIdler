using KasherOriginal.Factories.UIFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class MainMenuState : State<GameInstance>
    {
        public MainMenuState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }

        private readonly IUIFactory _uiFactory;

        private MainMenuScreen MainMenuScreen;

        public override void Enter()
        {
            ShowUI();
        }

        public override void Exit()
        {
            HideUI();
        }

        private async void ShowUI()
        {
            var mainMenuScreenInstance = await _uiFactory.CreateMainMenuScreen();

            if (mainMenuScreenInstance.TryGetComponent(out MainMenuScreen mainMenuScreen))
            {
                MainMenuScreen = mainMenuScreen;

                MainMenuScreen.OnPlayButtonClicked += ChangeStateToGameplay;
            }
        }
        private void HideUI()
        {
            if (MainMenuScreen != null)
            {
                MainMenuScreen.OnPlayButtonClicked -= ChangeStateToGameplay;
            }
            
            _uiFactory.DestroyMainMenuScreen();
        }

        private void ChangeStateToGameplay()
        {
           Context.StateMachine.SwitchState<GameLoadingState>(); 
        }
    }
}