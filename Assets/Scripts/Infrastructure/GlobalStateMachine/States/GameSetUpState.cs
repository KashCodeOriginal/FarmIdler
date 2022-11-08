using UnityEngine;
using KasherOriginal.Settings;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.AbstractFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameSetUpState : State<GameInstance>
    {
        public GameSetUpState(GameInstance context, IAbstractFactory abstractFactory, IAssetsAddressableService assetsAddressableService, GameSettings gameSettings) : base(context)
        {
            _abstractFactory = abstractFactory;
            _assetsAddressableService = assetsAddressableService;
            _gameSettings = gameSettings;
        }

        private readonly IAbstractFactory _abstractFactory;
        private readonly IAssetsAddressableService _assetsAddressableService;
        private readonly GameSettings _gameSettings;

        public override async void Enter()
        {
            Context.StateMachine.SwitchState<GameplayState>();

            var baseMapPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_MAP);
            var mainCameraPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.MAIN_CAMERA);
            var bedSpawnerPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BED_SPAWNER);
            var baseFarmerPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_FARMER);

            var mapInstance = _abstractFactory.CreateInstance(baseMapPrefab, _gameSettings.BaseMapPosition);
            var cameraInstance = _abstractFactory.CreateInstance(mainCameraPrefab, _gameSettings.CameraInstancePosition);
            var bedSpawnerInstance = _abstractFactory.CreateInstance(bedSpawnerPrefab, Vector3.zero);
            var farmerInstance = _abstractFactory.CreateInstance(baseFarmerPrefab, _gameSettings.PlayerSpawnPosition);

            cameraInstance.transform.rotation = _gameSettings.CameraInstanceRotation;
        }
    }
}