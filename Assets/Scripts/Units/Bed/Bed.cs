using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField] private BedCellType _bedCellType;

    private BedMeshHandler _bedMeshHandler;

    public BedCellType BedCellType => _bedCellType;

    private void Start()
    {
        _bedMeshHandler = GetComponent<BedMeshHandler>();
    }

    public void SetBedType(BedCellType bedCellType)
    {
        _bedCellType = bedCellType;
    }

    public void SetBedMesh()
    {
        _bedMeshHandler.SetBedMesh(_bedCellType);
    }
}
