using Zenject;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.UIFactory;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindUIFactory();
        BindAbstractFactory();
        BindAssetsAddressable();
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
}
