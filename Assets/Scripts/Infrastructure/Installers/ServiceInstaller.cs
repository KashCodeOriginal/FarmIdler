using Zenject;
using UnityEngine;
using KasherOriginal.Settings;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.UIFactory;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _gameSettings;
    
    public override void InstallBindings()
    {
        BindUIFactory();
        BindBedFactory();
        BindGameSettings();
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
    
    private void BindGameSettings()
    {
        Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();
    }
}
