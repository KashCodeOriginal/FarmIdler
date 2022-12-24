using System;

namespace Data.Dynamic
{
    [Serializable]
    public class PlayerProgress
    {
        public PlayerProgress()
        {
            WorldData = new WorldData();
            LootData = new LootData();
            PlayerData = new PlayerData();
        }

        public WorldData WorldData;
        public LootData LootData;
        public PlayerData PlayerData;
    }
}