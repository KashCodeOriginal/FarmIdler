using Data.Dynamic;

namespace Services.SaveLoad
{
    public interface ISaveLoadService
    {
        public void SaveProgress();
        public PlayerProgress LoadProgress();
    }
}