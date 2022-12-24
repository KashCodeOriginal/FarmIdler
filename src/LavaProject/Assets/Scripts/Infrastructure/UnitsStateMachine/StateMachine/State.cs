namespace Infrastructure.UnitsStateMachine.StateMachine
{
    public class State
    {
        public virtual void Enter(){}
        public virtual void Tick() {}
        public virtual void Exit() {} 
    }
}
