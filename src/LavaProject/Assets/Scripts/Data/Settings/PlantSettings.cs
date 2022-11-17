using UnityEngine;
using System.Collections.Generic;

namespace KasherOriginal.Settings
{
    [CreateAssetMenu(fileName = "PlantsSettings", menuName = "Settings/PlantsSettings")]
    public class PlantSettings : BaseSettings
    {
        [SerializeField] private List<BedCellStaticData> _bedCells;

        public List<BedCellStaticData> BedCells => _bedCells;
    }
}