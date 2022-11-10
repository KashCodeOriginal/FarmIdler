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

        private MainMenuScreen _mainMenuScreen;

        public override void Enter()
        {
            _uiFactory.DestroyMenuLoadingScreen();
            
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
                _mainMenuScreen = mainMenuScreen;

                _mainMenuScreen.OnPlayButtonClicked += ChangeStateToGameplay;
            }
        }
        private void HideUI()
        {
            if (_mainMenuScreen != null)
            {
                _mainMenuScreen.OnPlayButtonClicked -= ChangeStateToGameplay;
            }
            
            _uiFactory.DestroyMainMenuScreen();
        }

        private void ChangeStateToGameplay()
        {
           Context.StateMachine.SwitchState<GameLoadingState, MainMenuScreen>(_mainMenuScreen); 
        }
    }
}