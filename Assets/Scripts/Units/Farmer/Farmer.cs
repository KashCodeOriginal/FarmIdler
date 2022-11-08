using System;
using Pathfinding;
using UnityEngine;
using UnitsStateMachine;

public class Farmer : MonoBehaviour
{
    private StateMachine _stateMachine;

    private IMovable _movable;
    private AIDestinationSetter _aiDestinationSetter;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();

        _stateMachine = new StateMachine();

        var idle = new Idle();
        var moveToPoint = new MoveToTarget(_movable, _aiDestinationSetter);
        
        AddTransition(idle, moveToPoint, HasTarget);
        AddTransition(moveToPoint, idle, NoTargets);
        
        bool HasTarget() => _movable.MoveTargets.Count > 0;
        bool NoTargets() => _movable.MoveTargets.Count <= 0;
        
        _stateMachine.SetState(idle);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    private void AddTransition(State from, State to, Func<bool> condition)
    {
        _stateMachine.AddTransition(from, to, condition);
    }
}
