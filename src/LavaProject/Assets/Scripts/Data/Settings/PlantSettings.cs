using System.Collections.Generic;
using Units.Bed;
using UnityEngine;

namespace Data.Settings
{
    [CreateAssetMenu(fileName = "PlantsSettings", menuName = "Settings/PlantsSettings")]
    public class PlantSettings : BaseSettings
    {
        [SerializeField] private List<BedCellStaticData> _bedCells;

        public List<BedCellStaticData> BedCells => _bedCells;
    }
}