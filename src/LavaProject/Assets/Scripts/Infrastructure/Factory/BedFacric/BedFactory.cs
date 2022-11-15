﻿using System;
using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using KasherOriginal.Settings;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using KasherOriginal.AssetsAddressable;

public class BedFactory : IBedFactory
{
    public BedFactory(DiContainer container, IAssetsAddressableService assetsAddressableService, PlantSettings plantSettings)
    {
        _container = container;
        _assetsAddressableService = assetsAddressableService;
        _plantSettings = plantSettings;
    }

    private readonly DiContainer _container;
    private readonly IAssetsAddressableService _assetsAddressableService;
    private readonly PlantSettings _plantSettings;
    
    private List<GameObject> _instances = new List<GameObject>();

    public IReadOnlyList<GameObject> Instances
    {
        get => _instances;
    }
    
    public async Task<GameObject> CreateInstance(Vector3 spawnPoint)
    {
        var bedPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_BED);
        
        var instance = _container.InstantiatePrefab(bedPrefab, spawnPoint, Quaternion.identity, null);

        SetUp(instance);
        
        _instances.Add(instance);

        return instance;
    }

    private void SetUp(GameObject instance)
    {
        if (instance.TryGetComponent(out Bed bed))
        {
            bed.Construct(_plantSettings);
        }
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