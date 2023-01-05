using Data.Dynamic;
using Data.Dynamic.PlayerData;

namespace Services.SaveLoad
{
    public interface ISaveLoadService
    {
        public void SaveProgress();
        public PlayerProgress LoadProgress();
    }
}