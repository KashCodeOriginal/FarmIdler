using System;
using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using KasherOriginal.AssetsAddressable;

public class BedMeshHandler : MonoBehaviour
{
    [Inject]
    public void Construct(IAssetsAddressableService assetsAddressableService)
    {
        _assetsAddressableService = assetsAddressableService;
    }
    
    [SerializeField] private MeshFilter _meshFilter;

    private IAssetsAddressableService _assetsAddressableService;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetBedMesh(BedCellType.Carrot);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetBedMesh(BedCellType.Tree);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetBedMesh(BedCellType.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            SetBedMesh(BedCellType.Grass);
        }
    }

    public async void SetBedMesh(BedCellType bedCellType)
    {
        var meshPrefab = await GetMeshType(bedCellType);

        if (meshPrefab != null)
        {
            if (meshPrefab.TryGetComponent(out MeshFilter meshFilter))
            {
                _meshFilter.sharedMesh = meshFilter.sharedMesh;
            }
        }
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
