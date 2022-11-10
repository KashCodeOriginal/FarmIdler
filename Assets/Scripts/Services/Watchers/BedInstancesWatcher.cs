using UnityEngine;
using UnityEngine.Events;
using KasherOriginal.Settings;
using System.Collections.Generic;
using KasherOriginal.Factories.UIFactory;

public class BedInstancesWatcher : IBedInstancesWatcher
{
    public BedInstancesWatcher(IBedFactory bedFactory, IUIFactory uiFactory, PlantSettings plantSettings)
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
        if (bed.BedCellType == BedCellType.Empty)
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

                var plantImage = bed.GetPlantImage();
                
                plantInfoScreen.SetPlantInfo(bed.BedCellType.ToString(), plantImage);
                
                
            }

            if (bed.GetComponentInChildren<PlantsGrowing>())
            {
                var plantsGrowing = bed.GetComponentInChildren<PlantsGrowing>();

                if (plantsGrowing.WasPlantGrown && bed.BedCellType != BedCellType.Tree)
                {
                    plantInfoScreen.MakeButtonInteractable();
                }
                else
                {
                    plantInfoScreen.MakeButtonUnInteractable();
                }
            }
        }

        void PlantWasChosen(BedCellType bedCellType)
        {
            bed.SetBedType(bedCellType);
            
            IsBedModified?.Invoke(bed);
            
            _uiFactory.DestroyPlantChooseScreen();
        }

        void PlantWasCollected()
        {
            bed.SetBedType(BedCellType.Empty);
            bed.SetBedMesh();
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