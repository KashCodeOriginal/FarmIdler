using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Factory.BedFacric
{
    public interface IBedFactoryInfo
    {
        public IReadOnlyList<GameObject> Instances { get; }
    }
}