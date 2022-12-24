using System;
using Animations;
using UnityEngine;

namespace Units.Farmer
{
    public class FarmerAnimator : MonoBehaviour, IAnimatorStateReader
    {
        [SerializeField] private Animator _animator;

        public AnimatorState State { get; private set; }

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        private readonly int _walkHash = Animator.StringToHash("IsWalking");

        private readonly int _sitStateHash = Animator.StringToHash("Sit");
        private readonly int _walkStateHash = Animator.StringToHash("Walk");

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash)
        {
            State = StateFor(stateHash);
            StateExited?.Invoke(State);
        }

        public void SetWalkState(bool isStateActive)
        {
            _animator.SetBool(_walkHash, isStateActive);
        }

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            
            state = stateHash == _walkHash ? AnimatorState.Walk : AnimatorState.Sit;
            
            return state;
        }
    }
}
