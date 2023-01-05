using System;

namespace Data.Dynamic.PlayerData
{
    [Serializable]
    public class PositionOnLevel
    {
        public PositionOnLevel() { }
        public PositionOnLevel(Vector3Data position)
        {
            Position = position;
        }
        
        public Vector3Data Position;
    }
}