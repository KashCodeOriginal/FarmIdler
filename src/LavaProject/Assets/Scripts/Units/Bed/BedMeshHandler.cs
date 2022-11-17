using Zenject;
using UnityEngine;
using KasherOriginal.Factories.AbstractFactory;

public class BedMeshHandler : MonoBehaviour
{
    [Inject]
    public void Construct(IAbstractFactory abstractFactory)
    {
        _abstractFactory = abstractFactory;
    }

    [SerializeField] private Transform _spawnPosition;

    private GameObject _currentPlant;

    private IAbstractFactory _abstractFactory;

    public void SetBedMesh(BedCellStaticData bedCellStaticData)
    {
        if (bedCellStaticData == null)
        {
            Destroy(_currentPlant);
            return;
        }
        
        var plantPrefab = bedCellStaticData.Prefab;

        if (plantPrefab != null)
        {
            _currentPlant = _abstractFactory.CreateInstance(plantPrefab, _spawnPosition.position);
        
            _currentPlant.transform.SetParent(transform);
            
            SetGrowingTime(_currentPlant, bedCellStaticData.TimeBetweenGrowingStages);
        }
    }

    private void SetGrowingTime(GameObject plant, int time)
    {
        if (plant.TryGetComponent(out PlantsGrowing plantsGrowing))
        {
            plantsGrowing.SetStageTime(time);
        }
    }
}
