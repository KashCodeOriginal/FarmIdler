using System;

namespace Infrastructure.UnitsStateMachine.StateMachine
{
    public class Transition
    {
        public State To { get; }
        public Func<bool> Condition { get; }

        public Transition(State to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }
}