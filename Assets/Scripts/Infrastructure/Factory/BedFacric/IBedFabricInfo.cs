using UnityEngine;
using System.Collections.Generic;

public interface IBedFabricInfo
{
    public IReadOnlyList<GameObject> Instances { get; }
}