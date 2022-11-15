using UnityEngine;
using UnitsStateMachine;

public class Idle : State
{
    public Idle(Animator animator)
    {
        _animator = animator;
    }
    
    private Animator _animator;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    public override void Enter()
    {
        _animator.SetBool(IsWalking, false);
    }
}
