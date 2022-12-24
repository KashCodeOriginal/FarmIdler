using Data.AssetsAdressable;
using Data.Settings;
using Infrastructure.Factory.AbstractFactory;
using Infrastructure.GlobalStateMachine.StateMachine;
using Services.AssetsAddressableService;
using Services.Watchers;
using Services.Watchers.SaveLoadWatcher;
using UI.MainMenu;
using UnityEngine;

namespace Infrastructure.GlobalStateMachine.States
{
    public class GameSetUpState : StateOneParam<GameInstance, MainMenuScreen>
    {
        public GameSetUpState(GameInstance context, 
            IAbstractFactory abstractFactory, 
            IAssetsAddressableService assetsAddressableService, 
            GameSettings gameSettings, 
            IBedInstancesWatcher bedInstancesWatcher,
            ISaveLoadInstancesWatcher saveLoadInstancesWatcher) : base(context)
        {
            _abstractFactory = abstractFactory;
            _assetsAddressableService = assetsAddressableService;
            _gameSettings = gameSettings;
            _bedInstancesWatcher = bedInstancesWatcher;
            _saveLoadInstancesWatcher = saveLoadInstancesWatcher;
        }

        private readonly IAbstractFactory _abstractFactory;
        private readonly IAssetsAddressableService _assetsAddressableService;
        private readonly GameSettings _gameSettings;
        private readonly IBedInstancesWatcher _bedInstancesWatcher;
        private readonly ISaveLoadInstancesWatcher _saveLoadInstancesWatcher;

        public override async void Enter(MainMenuScreen mainMenuScreen)
        {
            var baseMapPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_MAP);
            var mainCameraPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.MAIN_CAMERA);
            var bedSpawnerPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BED_SPAWNER);
            var baseFarmerPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_FARMER);
            var pathfindingPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.PATHFINDING);

            var mapInstance = _abstractFactory.CreateInstance(baseMapPrefab, _gameSettings.BaseMapPosition);
            var cameraInstance = _abstractFactory.CreateInstance(mainCameraPrefab, _gameSettings.CameraInstancePosition);
            var bedSpawnerInstance = _abstractFactory.CreateInstance(bedSpawnerPrefab, Vector3.zero);
            var farmerInstance = _abstractFactory.CreateInstance(baseFarmerPrefab, _gameSettings.PlayerSpawnPosition);
            var pathfindingInstance = _abstractFactory.CreateInstance(pathfindingPrefab,  _gameSettings.BaseMapPosition);

            cameraInstance.transform.rotation = _gameSettings.CameraInstanceRotation;
            _bedInstancesWatcher.SetUp(farmerInstance);

            if (bedSpawnerInstance.TryGetComponent(out BedSpawner.BedSpawner bedSpawner))
            {
                bedSpawner.SetUp(mainMenuScreen);
                bedSpawner.CreateBeds();
            }
            
            _saveLoadInstancesWatcher.RegisterProgress(farmerInstance);

            Context.StateMachine.SwitchState<ProgressLoadingState, GameObject>(farmerInstance);
        }
    }
}