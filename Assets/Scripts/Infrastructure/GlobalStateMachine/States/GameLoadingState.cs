using UnityEngine;
using UnityEngine.AddressableAssets;
using KasherOriginal.Factories.UIFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameLoadingState : StateOneParam<GameInstance, MainMenuScreen>
    {
        public GameLoadingState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }
        
        private readonly IUIFactory _uiFactory;

        private GameObject GameLoadingScreenInstance;

        private MainMenuScreen _mainMenuScreen;

        public override async void Enter(MainMenuScreen mainMenuScreen)
        {
            _mainMenuScreen = mainMenuScreen;
            
            ShowUI();
            
            var asyncOperationHandle = Addressables.LoadSceneAsync(AssetsAddressablesConstants.GAMEPLAY_LEVEL_NAME);
            await asyncOperationHandle.Task;

            OnLoadComplete();
        }
        
        private void ShowUI()
        {
            _uiFactory.CreateGameLoadingScreen();
        }

        private void OnLoadComplete()
        {
            Context.StateMachine.SwitchState<GameSetUpState, MainMenuScreen>(_mainMenuScreen);
        }
    }
}