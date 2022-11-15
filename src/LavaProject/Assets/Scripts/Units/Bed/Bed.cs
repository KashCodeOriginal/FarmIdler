using Zenject;
using UnityEngine;
using KasherOriginal.Settings;

public class Bed : MonoBehaviour
{
    public void Construct(PlantSettings plantSettings)
    {
        _plantSettings = plantSettings;
    }
    
    [SerializeField] private BedCellType _bedCellType;

    private BedMeshHandler _bedMeshHandler;

    private PlantSettings _plantSettings;

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

    public Sprite GetPlantImage()
    {
        switch (_bedCellType)
        {
            case BedCellType.Empty:
                break;
            case BedCellType.Carrot:
                return _plantSettings.CarrotImage;
            case BedCellType.Tree:
                return _plantSettings.TreeImage;
            case BedCellType.Grass:
                return _plantSettings.GrassImage;
        }

        return null;
    }
}
