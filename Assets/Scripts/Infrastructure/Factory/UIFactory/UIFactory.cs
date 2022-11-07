using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using KasherOriginal.AssetsAddressable;

namespace KasherOriginal.Factories.UIFactory
{
    public class UIFactory : IUIFactory
    {
        public UIFactory(DiContainer container, IAssetsAddressableService assetsAddressableService)
        {
            _container = container;
            _assetsAddressableService = assetsAddressableService;
        }

        private readonly IAssetsAddressableService _assetsAddressableService;

        private readonly DiContainer _container;

        public GameObject MenuLoadingScreen { get; private set; }
        public GameObject MainMenuScreen { get; private set; }
        public GameObject GameLoadingScreen { get; private set; }
        public GameObject GameplayScreen { get; private set; }

        public async Task<GameObject> CreateMenuLoadingScreen()
        {
            var loadingScreenPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.GAME_LOADING_SCREEN);

            MenuLoadingScreen = _container.InstantiatePrefab(loadingScreenPrefab);

            return MenuLoadingScreen;
        }

        public void DestroyMenuLoadingScreen()
        {
            Object.Destroy(MenuLoadingScreen);
        }

        public async Task<GameObject> CreateMainMenuScreen()
        {
            var mainMenuScreenPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.MAIN_MENU_SCREEN);

            MainMenuScreen = _container.InstantiatePrefab(mainMenuScreenPrefab);

            return MainMenuScreen;
        }

        public void DestroyMainMenuScreen()
        {
            Object.Destroy(MainMenuScreen);
        }

        public async Task<GameObject> CreateGameLoadingScreen()
        {
            var loadingScreenPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.GAME_LOADING_SCREEN);

            GameLoadingScreen = _container.InstantiatePrefab(loadingScreenPrefab);

            return GameLoadingScreen;
        }

        public void DestroyGameLoadingScreen()
        {
            Object.Destroy(GameLoadingScreen);
        }

        public async Task<GameObject> CreateGameplayScreen()
        {
            var gameplayScreenPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.GAMEPLAY_SCREEN);

            GameplayScreen = _container.InstantiatePrefab(gameplayScreenPrefab);

            return GameplayScreen;
        }

        public void DestroyGameplayScreen()
        {
            Object.Destroy(GameplayScreen);
        }
    }
}

