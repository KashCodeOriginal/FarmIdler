namespace Animations
{
    public interface IAnimatorStateReader
    {
        public AnimatorState State { get; }
        public void EnteredState(int stateHash);
        public void ExitedState(int stateHash);
    }
}