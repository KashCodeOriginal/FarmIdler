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
        }

        public WorldData WorldData;
        public LootData LootData;
    }
}