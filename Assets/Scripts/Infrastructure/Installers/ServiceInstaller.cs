using Zenject;
using UnityEngine;
using KasherOriginal.Settings;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.UIFactory;

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
}
