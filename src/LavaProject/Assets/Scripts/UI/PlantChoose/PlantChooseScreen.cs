using Zenject;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using KasherOriginal.Settings;
using KasherOriginal.Factories.UIFactory;

public class PlantChooseScreen : MonoBehaviour
{
    [Inject]
    public void Construct(IUIFactory uiFactory, PlantSettings plantSettings)
    {
        _plantSettings = plantSettings;
        _uiFactory = uiFactory;
    }

    public event UnityAction<BedCellStaticData> IsChooseButtonClicked;

    [SerializeField] private Button _closePanelButton;
    [SerializeField] private Button _closePanelBackgroundButton;
    [SerializeField] private Transform _parent;

    private IUIFactory _uiFactory;
    private PlantSettings _plantSettings;

    private async void Start()
    {
        foreach (var bedCellData in _plantSettings.BedCells)
        {
            var button = await _uiFactory.CreateBedChooseButton();

            if (button.TryGetComponent(out ChooseButton chooseButton))
            {
                chooseButton.SetUp(bedCellData);
            }
            
            button.onClick.AddListener(delegate { ChooseButtonClicked(bedCellData);});
            
            button.transform.SetParent(_parent);
        }

        _closePanelButton.onClick.AddListener(DestroyScreen);
        _closePanelBackgroundButton.onClick.AddListener(DestroyScreen);
    }

    private void DestroyScreen()
    {
        _uiFactory.DestroyPlantChooseScreen();
    }

    private void ChooseButtonClicked(BedCellStaticData bedCellStaticData)
    {
        IsChooseButtonClicked?.Invoke(bedCellStaticData);
    }
}
