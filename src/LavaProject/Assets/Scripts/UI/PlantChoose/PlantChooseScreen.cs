using Zenject;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using KasherOriginal.Factories.UIFactory;

public class PlantChooseScreen : MonoBehaviour
{
    [Inject]
    public void Construct(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }

    private IUIFactory _uiFactory;
    
    public event UnityAction<BedCellType> IsChooseButtonClicked;
    
    [SerializeField] private Button _carrotChooseButton;
    [SerializeField] private Button _treeChooseButton;
    [SerializeField] private Button _grassChooseButton;
    
    [SerializeField] private Button _closePanelButton;
    [SerializeField] private Button _closePanelBackgroundButton;

    private void Start()
    {
        _carrotChooseButton.onClick.AddListener(delegate { IsChooseButtonClicked?.Invoke(BedCellType.Carrot); });
        _treeChooseButton.onClick.AddListener(delegate { IsChooseButtonClicked?.Invoke(BedCellType.Tree); });
        _grassChooseButton.onClick.AddListener(delegate { IsChooseButtonClicked?.Invoke(BedCellType.Grass); });
        
        _closePanelButton.onClick.AddListener(DestroyScreen);
        _closePanelBackgroundButton.onClick.AddListener(DestroyScreen);
    }

    private void DestroyScreen()
    {
        _uiFactory.DestroyPlantChooseScreen();
    }
}
