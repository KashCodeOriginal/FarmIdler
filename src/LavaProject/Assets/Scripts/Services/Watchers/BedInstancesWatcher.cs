using System;
using UnityEngine;
using UnityEngine.Events;
using KasherOriginal.Settings;
using System.Collections.Generic;
using KasherOriginal.Factories.UIFactory;
using Random = UnityEngine.Random;

public class BedInstancesWatcher : IBedInstancesWatcher
{
    public BedInstancesWatcher(IBedFactory bedFactory, IUIFactory uiFactory)
    {
        _bedFactory = bedFactory;
        _uiFactory = uiFactory;
    }

    public event UnityAction<Bed> IsBedModified;

    private readonly IBedFactory _bedFactory;
    private readonly IUIFactory _uiFactory;

    private List<GameObject> _instances = new List<GameObject>();

    private GameObject _playerInstance;

    public IReadOnlyList<GameObject> Instances => _instances;

    public void SetUp(GameObject playerInstance)
    {
        _playerInstance = playerInstance;

        if (_playerInstance.TryGetComponent(out IMovable movable))
        {
            movable.IsBedVisited += SetBedModel;
        }
    }

    public void Register(GameObject bedInstance)
    {
        _instances.Add(bedInstance);

        if (bedInstance.TryGetComponent(out BedInteractable bedInteractable))
        {
            bedInteractable.IsBedInteracted += BedWasInteracted;
        }
    }

    public void DestroyAllInstances()
    {
        _bedFactory.DestroyAllInstances();
    }

    private async void BedWasInteracted(Bed bed)
    {
        BedCellStaticData bedCellStaticData = bed.BedCellStaticSata;
        
        if (bedCellStaticData == null)
        {
            var plantChooseScreenInstance = await  _uiFactory.CreatePlantChooseScreen();

            if (plantChooseScreenInstance.TryGetComponent(out PlantChooseScreen plantChooseScreen))
            {
                plantChooseScreen.IsChooseButtonClicked += PlantWasChosen;
            }
        }
        else
        {
            var plantInfoScreenInstance =  await _uiFactory.CreatePlantInfoScreen();

            if (plantInfoScreenInstance.TryGetComponent(out PlantInfoScreen plantInfoScreen))
            {
                plantInfoScreen.IsCollectButtonClicked += PlantWasCollected;

                var plantImage = bedCellStaticData.Icon;
                
                plantInfoScreen.SetPlantInfo(bedCellStaticData.Name, plantImage);
            }

            if (bed.GetComponentInChildren<PlantsGrowing>())
            {
                var plantsGrowing = bed.GetComponentInChildren<PlantsGrowing>();
                
                if (plantsGrowing.WasPlantGrown && bedCellStaticData.IsExperienceGivable)
                {
                    plantInfoScreen.MakeButtonInteractable();
                }
                else
                {
                    plantInfoScreen.MakeButtonUnInteractable();
                }
            }
        }

        void PlantWasChosen(BedCellStaticData newBedCellStaticData)
        {
            bed.SetBedType(newBedCellStaticData);
            
            IsBedModified?.Invoke(bed);
            
            _uiFactory.DestroyPlantChooseScreen();
        }

        void PlantWasCollected()
        {
            if (_playerInstance.TryGetComponent(out FarmerExperience farmerExperience))
            {
                farmerExperience.AddExperience(bedCellStaticData.Experience);
            }

            if (bedCellStaticData.IsCollectable)
            {
                if (_playerInstance.TryGetComponent(out FarmerInventory farmerInventory))
                {
                    farmerInventory.AddCarrot(Random.Range(1, 3));
                }
            }
            
            bed.SetBedType(null);
        }
    }

    private void SetBedModel(GameObject bedInstance)
    {
        if (bedInstance.TryGetComponent(out Bed bed))
        {
            bed.SetBedMesh();
        }
    }
}