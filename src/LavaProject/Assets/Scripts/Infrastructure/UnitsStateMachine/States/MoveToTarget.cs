using Infrastructure.UnitsStateMachine.StateMachine;
using Pathfinding;
using Units.Farmer;
using Units.Farmer.Model;
using UnityEngine;

namespace Infrastructure.UnitsStateMachine.States
{
    public class MoveToTarget : State
    {
        public MoveToTarget(IMovable movable, AIDestinationSetter aiDestinationSetter, FarmerAnimator animator)
        {
            _movable = movable;
            _aiDestinationSetter = aiDestinationSetter;
            _animator = animator;
        }

        private readonly IMovable _movable;

        private readonly AIDestinationSetter _aiDestinationSetter;

        private readonly FarmerAnimator _animator;
        
        public override void Enter()
        {
            _animator.SetWalkState(true);
        }

        public override void Tick()
        {
            _movable.MoveToPoint(_aiDestinationSetter);
        }
    }
}