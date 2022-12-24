using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.AssetsAdressable;
using Services.AssetsAddressableService;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.Factory.BedFacric
{
    public class BedFactory : IBedFactory
    {
        public BedFactory(DiContainer container, IAssetsAddressableService assetsAddressableService)
        {
            _container = container;
            _assetsAddressableService = assetsAddressableService;
        }

        private readonly DiContainer _container;
        private readonly IAssetsAddressableService _assetsAddressableService;

        private List<GameObject> _instances = new List<GameObject>();

        public IReadOnlyList<GameObject> Instances
        {
            get => _instances;
        }
    
        public async Task<GameObject> CreateInstance(Vector3 spawnPoint)
        {
            var bedPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_BED);
        
            var instance = _container.InstantiatePrefab(bedPrefab, spawnPoint, Quaternion.identity, null);

            _instances.Add(instance);

            return instance;
        }

        public void DestroyInstance(GameObject instance)
        {
            if (instance == null)
            {
                throw new NullReferenceException("There is no instance to destroy");
            }
        
            if (!_instances.Contains(instance))
            {
                throw new NullReferenceException($"Instance {instance} can't be destroyed, cause there is no {instance} on Abstract Factory Instances");
            }
        
            Object.Destroy(instance);
            _instances.Remove(instance);
        }

        public void DestroyAllInstances()
        {
            for (int i = 0; i < _instances.Count; i++)
            {
                Object.Destroy(_instances[i]);
            }
        
            _instances.Clear();
        }
    }
}