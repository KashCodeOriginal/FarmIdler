using Infrastructure.Factory.UIFactory;
using Infrastructure.GlobalStateMachine.StateMachine;
using Services.PersistentProgress;
using UI.GameplayScreen;
using UnityEngine;

namespace Infrastructure.GlobalStateMachine.States
{
    public class GameplayState : StateOneParam<GameInstance, GameObject>
    {
        public GameplayState(GameInstance context, IUIFactory uiFactory, IPersistentProgressService persistentProgressService) : base(context)
        {
            _uiFactory = uiFactory;
            _persistentProgressService = persistentProgressService;
        }

        private readonly IUIFactory _uiFactory;
        private readonly IPersistentProgressService _persistentProgressService;
        private GameObject _gameplayScreenInstance;

        public override async void Enter(GameObject farmerInstance)
        {
            _gameplayScreenInstance = await _uiFactory.CreateGameplayScreen();

            if (_gameplayScreenInstance.TryGetComponent(out GameplayScreen gameplayScreen))
            {
                gameplayScreen.SetUp(_persistentProgressService);
            }

            _uiFactory.DestroyMenuLoadingScreen();
            _uiFactory.DestroyGameLoadingScreen();
        }
    }
}