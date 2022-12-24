using Infrastructure.Factory.BedFacric;
using Services.Watchers;
using UI.MainMenu;
using UnityEngine;
using Zenject;

namespace BedSpawner
{
    public class BedSpawner : MonoBehaviour
    {
        [Inject]
        public void Construct(IBedFactory bedFactory, IBedInstancesWatcher bedInstancesWatcher)
        {
            _bedFactory = bedFactory;
            _bedInstancesWatcher = bedInstancesWatcher;
        }
    
        private float _mapHeight = 0.3f;
    
        private float _distance = 5f;

        private Vector3 _centerPosition;

        private IBedFactory _bedFactory;
        private IBedInstancesWatcher _bedInstancesWatcher;

        private MainMenuScreen _mainMenuScreen;

        public void SetUp(MainMenuScreen mainMenuScreen)
        {
            _mainMenuScreen = mainMenuScreen;
        }

        public async void CreateBeds()
        {
            _centerPosition = new Vector3(_mainMenuScreen.RowsValue * -2.2f, _mapHeight, _mainMenuScreen.ColumnsValue * -2.8f);
        
            for (int x = 0; x < _mainMenuScreen.RowsValue; x++)
            {
                for (int y = 0; y < _mainMenuScreen.ColumnsValue; y++)
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
}
