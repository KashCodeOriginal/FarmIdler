using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Factory.UIFactory
{
    public interface IUIFactory : IUIInfo
    {
        public Task<GameObject> CreateMenuLoadingScreen();
        public void DestroyMenuLoadingScreen();
        public Task<GameObject> CreateMainMenuScreen();
        public void DestroyMainMenuScreen();
        public Task<GameObject> CreateGameLoadingScreen();
        public void DestroyGameLoadingScreen();
        public Task<GameObject> CreateGameplayScreen();
        public void DestroyGameplayScreen();
        public Task<GameObject> CreatePlantChooseScreen();
        public void DestroyPlantChooseScreen();
        public Task<GameObject> CreatePlantInfoScreen();
        public void DestroyPlantInfoScreen();
        Task<Button> CreateBedChooseButton();
    }
}

