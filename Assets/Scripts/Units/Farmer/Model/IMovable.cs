using UnityEngine;
using Pathfinding;
using System.Collections.Generic;

public interface IMovable
{
    public IReadOnlyList<Transform> MoveTargets { get; }
    public void MoveToPoint(AIDestinationSetter aiDestinationSetter);
    public void AddMovingPoint(Transform point);
}