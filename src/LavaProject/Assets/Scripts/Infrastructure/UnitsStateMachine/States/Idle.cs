using Units.Farmer;
using Infrastructure.UnitsStateMachine.StateMachine;

namespace Infrastructure.UnitsStateMachine.States
{
    public class Idle : State
    {
        public Idle(FarmerAnimator animator)
        {
            _animator = animator;
        }
    
        private readonly FarmerAnimator _animator;

        public override void Enter()
        {
            _animator.SetWalkState(false);
        }
    }
}
