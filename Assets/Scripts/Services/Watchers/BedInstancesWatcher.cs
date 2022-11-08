using System.Collections.Generic;
using KasherOriginal.Factories.UIFactory;
using UnityEngine;

public class BedInstancesWatcher : IBedInstancesWatcher
{
    public BedInstancesWatcher(IBedFactory bedFactory, IUIFactory uiFactory)
    {
        _bedFactory = bedFactory;
        _uiFactory = uiFactory;
    }

    private readonly IBedFactory _bedFactory;
    private readonly IUIFactory _uiFactory;
    
    private List<GameObject> _instances = new List<GameObject>();

    public IReadOnlyList<GameObject> Instances => _instances;

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
            _uiFactory.CreatePlantInfoScreen();
        }

        void PlantWasChosen(BedCellType bedCellType)
        {
            bed.SetBedType(bedCellType);
        }
    }
}