using Pathfinding;
using UnitsStateMachine;

public class MoveToTarget : State
{
    private readonly IMovable _movable;
    private readonly AIDestinationSetter _aiDestinationSetter;

    public MoveToTarget(IMovable movable, AIDestinationSetter aiDestinationSetter)
    {
        _movable = movable;
        _aiDestinationSetter = aiDestinationSetter;
    }

    public override void Tick()
    {
        _movable.MoveToPoint(_aiDestinationSetter);
    }
}