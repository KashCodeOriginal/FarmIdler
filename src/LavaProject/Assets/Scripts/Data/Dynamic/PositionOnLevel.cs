using System;

namespace Data.Dynamic
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