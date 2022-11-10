using UnityEngine;
using KasherOriginal.Settings;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.AbstractFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameSetUpState : StateOneParam<GameInstance, MainMenuScreen>
    {
        public GameSetUpState(GameInstance context, IAbstractFactory abstractFactory, IAssetsAddressableService assetsAddressableService, GameSettings gameSettings, IBedInstancesWatcher bedInstancesWatcher) : base(context)
        {
            _abstractFactory = abstractFactory;
            _assetsAddressableService = assetsAddressableService;
            _gameSettings = gameSettings;
            _bedInstancesWatcher = bedInstancesWatcher;
        }

        private readonly IAbstractFactory _abstractFactory;
        private readonly IAssetsAddressableService _assetsAddressableService;
        private readonly GameSettings _gameSettings;
        private readonly IBedInstancesWatcher _bedInstancesWatcher;

        public override async void Enter(MainMenuScreen mainMenuScreen)
        {
            Context.StateMachine.SwitchState<GameplayState>();

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

            if (bedSpawnerInstance.TryGetComponent(out BedSpawner bedSpawner))
            {
                bedSpawner.SetUp(mainMenuScreen);
                bedSpawner.CreateBeds();
            }
        }
    }
}