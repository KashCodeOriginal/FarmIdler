using Data.Settings;
using Infrastructure.Factory.AbstractFactory;
using Infrastructure.Factory.UIFactory;
using Infrastructure.GlobalStateMachine.StateMachine;
using Infrastructure.GlobalStateMachine.States;
using Services.AssetsAddressableService;
using Services.PersistentProgress;
using Services.SaveLoad;
using Services.Watchers;
using Services.Watchers.SaveLoadWatcher;

namespace Infrastructure.GlobalStateMachine
{
    public class GameInstance
    {
        public GameInstance(IUIFactory uiFactory, 
            IAssetsAddressableService assetsAddressableService, 
            IAbstractFactory abstractFactory, 
            GameSettings gameSettings, 
            IBedInstancesWatcher bedInstancesWatcher,
            ISaveLoadInstancesWatcher saveLoadInstancesWatcher,
            IPersistentProgressService persistentProgressService,
            ISaveLoadService saveLoadService)
        {
            StateMachine = new StateMachine<GameInstance>(this, new BootstrapState(this),
                new SceneLoadingState(this, uiFactory),
                new MainMenuState(this, uiFactory),
                new GameLoadingState(this, uiFactory),
                new GameSetUpState(this, abstractFactory,
                    assetsAddressableService,
                    gameSettings,
                    bedInstancesWatcher,
                    saveLoadInstancesWatcher),
                new ProgressLoadingState(this, persistentProgressService, 
                    saveLoadService, 
                    saveLoadInstancesWatcher),
                new GameplayState(this, uiFactory, persistentProgressService)
            );
        
            StateMachine.SwitchState<BootstrapState>();
        }

        public readonly StateMachine<GameInstance> StateMachine;
    }
}
