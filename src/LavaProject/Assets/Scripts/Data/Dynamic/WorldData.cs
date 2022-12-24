using System;

namespace Data.Dynamic
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