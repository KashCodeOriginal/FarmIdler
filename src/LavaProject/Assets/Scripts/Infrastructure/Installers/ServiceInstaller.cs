using Data.Settings;
using Infrastructure.Factory.AbstractFactory;
using Infrastructure.Factory.BedFacric;
using Infrastructure.Factory.UIFactory;
using Services.AssetsAddressableService;
using Services.PersistentProgress;
using Services.SaveLoad;
using Services.Watchers;
using Services.Watchers.SaveLoadWatcher;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private PlantSettings _plantSettings;

        public override void InstallBindings()
        {
            BindSettings();
            BindUIFactory();
            BindBedFactory();
            BindAbstractFactory();
            BindAssetsAddressable();
            BindBedInstanceWatcher();
            BindPersistentProgressService();
            BindSaveLoadInstancesWatcher();
            BindSaveLoadService();
        }

        private void BindAssetsAddressable()
        {
            Container.BindInterfacesTo<AssetsAddressableService>().AsSingle();
        }

        private void BindUIFactory()
        {
            Container.BindInterfacesTo<UIFactory>().AsSingle();
        }
    
        private void BindAbstractFactory()
        {
            Container.BindInterfacesTo<AbstractFactory>().AsSingle();
        }
    
        private void BindBedFactory()
        {
            Container.BindInterfacesTo<BedFactory>().AsSingle();
        }
    
        private void BindBedInstanceWatcher()
        {
            Container.BindInterfacesTo<BedInstancesWatcher>().AsSingle();
        }
    
        private void BindSettings()
        {
            Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();
            Container.Bind<PlantSettings>().FromInstance(_plantSettings).AsSingle();
        }
    
        private void BindPersistentProgressService()
        {
            Container.BindInterfacesTo<PersistentProgressService>().AsSingle();
        }
        
        private void BindSaveLoadInstancesWatcher()
        {
            Container.BindInterfacesTo<SaveLoadInstancesWatcher>().AsSingle();
        }
        
        private void BindSaveLoadService()
        {
            Container.BindInterfacesTo<SaveLoadService>().AsSingle();
        }
    }
}
