using System;

namespace Data.Dynamic.PlayerData
{
    [Serializable]
    public class WorldData
    {
        public WorldData()
        {
            PositionOnLevel = new PositionOnLevel();
        }
        
        public PositionOnLevel PositionOnLevel;
    }
}