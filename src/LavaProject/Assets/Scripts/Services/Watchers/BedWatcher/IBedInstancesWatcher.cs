using System.Collections.Generic;
using Units.Bed;
using UnityEngine;
using UnityEngine.Events;

namespace Services.Watchers
{
    public interface IBedInstancesWatcher
    {
        public event UnityAction<Bed> IsBedModified; 
        public IReadOnlyList<GameObject> Instances { get; }
        public void SetUp(GameObject playerInstance);
        public void Register(GameObject bedInstance);
        public void DestroyAllInstances();
    }
}