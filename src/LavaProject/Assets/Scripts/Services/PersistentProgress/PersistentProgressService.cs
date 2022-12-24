using Data.Dynamic;

namespace Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress PlayerProgress { get; private set; }

        public void SetProgress(PlayerProgress playerProgress)
        {
            PlayerProgress = playerProgress;
        }
    }
}
