using System.Collections.Generic;
using Services.PersistentProgress;
using UnityEngine;

namespace Services.Watchers.SaveLoadWatcher
{
    public class SaveLoadInstancesWatcher : ISaveLoadInstancesWatcher
    {
        private List<IProgressSavable> _progressSavable = new List<IProgressSavable>();
        private List<IProgressLoadable> _progressLoadable = new List<IProgressLoadable>();

        public List<IProgressSavable> ProgressSavable => _progressSavable;

        public List<IProgressLoadable> ProgressLoadable => _progressLoadable;


        public void RegisterProgress(GameObject instance)
        {
            foreach (var progressLoader in instance.GetComponentsInChildren<IProgressLoadable>())
            {
                Register(progressLoader);
            }
        }

        private void Register(IProgressLoadable progressLoadable)
        {
            if (progressLoadable is IProgressSavable progressSavable)
            {
                _progressSavable.Add(progressSavable);
            }
            
            _progressLoadable.Add(progressLoadable);
        }
    }
}
