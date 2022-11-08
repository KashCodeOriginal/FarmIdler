using Zenject;
using UnityEngine;

public class BedSpawner : MonoBehaviour
{
    [Inject]
    public void Construct(IBedFactory bedFactory, IBedInstancesWatcher bedInstancesWatcher)
    {
        _bedFactory = bedFactory;
        _bedInstancesWatcher = bedInstancesWatcher;
    }

    [SerializeField] private int _rowsCount;
    [SerializeField] private int _columnsCount;
    
    [SerializeField] private float _mapHeight;
    
    [SerializeField] private float _distance;

    [SerializeField] private Vector3 _centerPosition;

    private IBedFactory _bedFactory;
    private IBedInstancesWatcher _bedInstancesWatcher;

    private void Start()
    {
        CreateBeds();
    }

    private async void CreateBeds()
    {
        for (int x = 0; x < _rowsCount; x++)
        {
            for (int y = 0; y < _columnsCount; y++)
            {
                var spawnPosition = GetSpawnPosition(x, y, _distance);

                var targetSpawnPosition = new Vector3(spawnPosition.x, _mapHeight, spawnPosition.z);

                var instance = await _bedFactory.CreateInstance(targetSpawnPosition);
                
                _bedInstancesWatcher.Register(instance);
            }
        }
        
        AstarPath.active.Scan();
    }
    
    Vector3 GetSpawnPosition(int row, int column, float distance)
    {
        return _centerPosition + 
               Vector3.forward * column * distance + 
               Vector3.right * row * distance;
    }
}
