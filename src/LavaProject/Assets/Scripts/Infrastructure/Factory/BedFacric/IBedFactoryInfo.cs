using UnityEngine;
using System.Collections.Generic;

public interface IBedFactoryInfo
{
    public IReadOnlyList<GameObject> Instances { get; }
}