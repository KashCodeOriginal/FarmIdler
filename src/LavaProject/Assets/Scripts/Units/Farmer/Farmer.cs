using System;
using Infrastructure.UnitsStateMachine.StateMachine;
using Infrastructure.UnitsStateMachine.States;
using Pathfinding;
using Units.Farmer.Model;
using UnityEngine;

namespace Units.Farmer
{
    public class Farmer : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private IMovable _movable;
        private AIDestinationSetter _aiDestinationSetter;
        private FarmerAnimator _animator;

        private void Awake()
        {
            _movable = GetComponent<IMovable>();
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            _animator = GetComponent<FarmerAnimator>();

            _stateMachine = new StateMachine();

            var idle = new Idle(_animator);
            var moveToPoint = new MoveToTarget(_movable, _aiDestinationSetter, _animator);
            var plant = new Plant();
            var moveToHome = new MoveToHome(_movable, _aiDestinationSetter, _animator);

            AddAnyTransition(moveToPoint, HasTarget);
            AddTransition(moveToPoint, plant, ReachedTarget);
            AddTransition(plant, moveToHome, NoTargets);
            AddTransition(moveToHome, idle, ReachedHome);

            bool HasTarget() => _movable.MoveTargets.Count > 0;
            bool ReachedTarget() => _movable.IsTargetReached == true;
            bool ReachedHome() => _movable.IsHomeReached == true;
            bool NoTargets() => _movable.MoveTargets.Count <= 0;
        
            _stateMachine.SetState(idle);
        }

        private void FixedUpdate()
        {
            _stateMachine.Tick();
        }

        private void AddTransition(State from, State to, Func<bool> condition)
        {
            _stateMachine.AddTransition(from, to, condition);
        }
    
        private void AddAnyTransition(State to, Func<bool> condition)
        {
            _stateMachine.AddAnyTransition(to, condition);
        }
    }
}
