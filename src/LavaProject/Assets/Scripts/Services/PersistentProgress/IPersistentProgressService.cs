using Data.Dynamic;

namespace Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        public PlayerProgress PlayerProgress { get; }
        public void SetProgress(PlayerProgress playerProgress);
    }
}