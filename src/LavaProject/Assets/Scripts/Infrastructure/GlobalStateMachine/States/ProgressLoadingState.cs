using Data.Dynamic;
using Data.Extensions;
using Infrastructure.GlobalStateMachine.StateMachine;
using Services.PersistentProgress;
using Services.SaveLoad;
using Services.Watchers.SaveLoadWatcher;
using UnityEngine;

namespace Infrastructure.GlobalStateMachine.States
{
    public class ProgressLoadingState : StateOneParam<GameInstance, GameObject>
    {
        public ProgressLoadingState(GameInstance context,
            IPersistentProgressService persistentProgressService,
            ISaveLoadService saveLoadService,
            ISaveLoadInstancesWatcher saveLoadInstancesWatcher) : base(context)
        {
            _persistentProgressService = persistentProgressService;
            _saveLoadService = saveLoadService;
            _saveLoadInstancesWatcher = saveLoadInstancesWatcher;
        }

        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ISaveLoadInstancesWatcher _saveLoadInstancesWatcher;

        public override void Enter(GameObject player)
        {
            LoadProgressOrInitNew();
            
            InformProgressReaders();

            Context.StateMachine.SwitchState<GameplayState, GameObject>(player);
        }

        private void LoadProgressOrInitNew()
        {
            _persistentProgressService.SetProgress(_saveLoadService.LoadProgress() ?? InitNewProgress());
        }

        private PlayerProgress InitNewProgress()
        {
            var progress = new PlayerProgress()
            {
                PlayerData =
                {
                    Experience = 0,
                    Level = 0,
                    MaxExperienceForLevel = 100
                }
            };

            return progress;
        }
        
        private void InformProgressReaders()
        {
            foreach (var progressLoadable in _saveLoadInstancesWatcher.ProgressLoadable)
            {
                progressLoadable.LoadProgress(_persistentProgressService.PlayerProgress);
            }
        }
    }
}
