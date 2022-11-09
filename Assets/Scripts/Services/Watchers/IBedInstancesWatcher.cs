using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public interface IBedInstancesWatcher
{
    public event UnityAction<Bed> IsBedModified; 
    public IReadOnlyList<GameObject> Instances { get; }
    public void SetUp(GameObject playerInstance);
    public void Register(GameObject bedInstance);
    public void DestroyAllInstances();
}