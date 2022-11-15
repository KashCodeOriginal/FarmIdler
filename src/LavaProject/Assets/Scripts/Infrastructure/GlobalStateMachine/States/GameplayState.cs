using KasherOriginal.Factories.UIFactory;
using UnityEngine;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameplayState : StateOneParam<GameInstance, GameObject>
    {
        public GameplayState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }

        private readonly IUIFactory _uiFactory;
        private GameObject _gameplayScreenInstance;

        public override async void Enter(GameObject farmerInstance)
        {
            _gameplayScreenInstance = await _uiFactory.CreateGameplayScreen();

            if (_gameplayScreenInstance.TryGetComponent(out GameplayScreen gameplayScreen))
            {
                var farmerExperience = farmerInstance.GetComponent<FarmerExperience>();
                var farmerInventory = farmerInstance.GetComponent<FarmerInventory>();
                gameplayScreen.SetUp(farmerExperience, farmerInventory);
            }

            _uiFactory.DestroyMenuLoadingScreen();
            _uiFactory.DestroyGameLoadingScreen();
        }
    }
}