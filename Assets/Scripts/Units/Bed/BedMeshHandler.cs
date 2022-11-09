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

    private IAssetsAddressableService _assetsAddressableService;
    private IAbstractFactory _abstractFactory;

    public async void SetBedMesh(BedCellType bedCellType)
    {
        var plantPrefab = await GetMeshType(bedCellType);

        var instance = _abstractFactory.CreateInstance(plantPrefab, _spawnPosition.position);
        
        instance.transform.SetParent(transform);
    }

    private async Task<GameObject> GetMeshType(BedCellType bedCellType)
    {
        switch (bedCellType)
        {
            case BedCellType.Empty:
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
