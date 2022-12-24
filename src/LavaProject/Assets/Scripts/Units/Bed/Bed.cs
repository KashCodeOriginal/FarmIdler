using UnityEngine;

namespace Units.Bed
{
    public class Bed : MonoBehaviour
    {
        private BedCellStaticData bedCellStaticData;

        private BedMeshHandler _bedMeshHandler;

        public BedCellStaticData BedCellStaticData => bedCellStaticData;

        private void Start()
        {
            _bedMeshHandler = GetComponent<BedMeshHandler>();
        }

        public void SetBedType(BedCellStaticData bedCellStaticData)
        {
            this.bedCellStaticData = bedCellStaticData;
        }

        public void SetBedMesh()
        {
            _bedMeshHandler.SetBedMesh(BedCellStaticData);
        }

        public void ResetBedMesh()
        {
            SetBedType(null);
            _bedMeshHandler.SetBedMesh(bedCellStaticData);
        }
    }
}
