using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.AbstractFactory;

public class BedMeshHandler : MonoBehaviour
{
    [Inject]
    public void Construct(IAssetsAddressableService assetsAddressableService, IAbstractFactory abstractFactory)
    {
        _assetsAddressableService = assetsAddressableService;
        _abstractFactory = abstractFactory;
    }

    [SerializeField] private Transform _spawnPosition;

    private GameObject _currentPlant;

    private IAssetsAddressableService _assetsAddressableService;
    private IAbstractFactory _abstractFactory;

    public async void SetBedMesh(BedCellType bedCellType)
    {
        var plantPrefab = await GetMeshType(bedCellType);

        if (plantPrefab != null)
        {
            _currentPlant = _abstractFactory.CreateInstance(plantPrefab, _spawnPosition.position);
        
            _currentPlant.transform.SetParent(transform);
        }
    }

    private async Task<GameObject> GetMeshType(BedCellType bedCellType)
    {
        switch (bedCellType)
        {
            case BedCellType.Empty:
                if (_currentPlant != null)
                {
                    Destroy(_currentPlant);
                }
                return null;
            case BedCellType.Carrot:
                var carrotPrefab = await GetAssetByPath(AssetsAddressablesConstants.BASE_CARROT);
                return carrotPrefab;
            case BedCellType.Tree:
                var treePrefab = await GetAssetByPath(AssetsAddressablesConstants.BASE_TREE);
                return treePrefab;
            case BedCellType.Grass:
                var grassPrefab = await GetAssetByPath(AssetsAddressablesConstants.BASE_GRASS);
                return grassPrefab;
        }

        return null;
    }

    private async Task<GameObject> GetAssetByPath(string path)
    {
        var prefab = await _assetsAddressableService.GetAsset<GameObject>(path);

        return prefab;
    }
}
