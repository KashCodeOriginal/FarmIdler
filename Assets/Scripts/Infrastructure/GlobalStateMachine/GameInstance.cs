using KasherOriginal.Settings;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.GlobalStateMachine;
using KasherOriginal.Factories.UIFactory;
using KasherOriginal.Factories.AbstractFactory;

public class GameInstance
{
    public GameInstance(IUIFactory uiFactory, IAssetsAddressableService assetsAddressableService, IAbstractFactory abstractFactory, GameSettings gameSettings)
    {
        StateMachine = new StateMachine<GameInstance>(this, new BootstrapState(this),
            new SceneLoadingState(this, uiFactory),
            new MainMenuState(this, uiFactory),
            new GameLoadingState(this, uiFactory),
            new GameSetUpState(this, abstractFactory, assetsAddressableService, gameSettings),
            new GameplayState(this, uiFactory)
            );
        
        StateMachine.SwitchState<BootstrapState>();
    }

    public readonly StateMachine<GameInstance> StateMachine;
}
