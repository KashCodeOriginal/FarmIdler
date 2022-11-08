using UnityEngine;
using System.Collections.Generic;

public interface IBedInstancesWatcher
{
    public IReadOnlyList<GameObject> Instances { get; }
    public void Register(GameObject bedInstance);
    public void DestroyAllInstances();
}