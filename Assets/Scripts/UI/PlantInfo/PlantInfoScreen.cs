using Zenject;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using KasherOriginal.Factories.UIFactory;

public class PlantInfoScreen : MonoBehaviour
{
    [Inject]
    public void Construct(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }

    public event UnityAction IsCollectButtonClicked;

    private IUIFactory _uiFactory;
    
    [SerializeField] private Button _closePanelButton;
    [SerializeField] private Button _closePanelBackgroundButton;
    
    [SerializeField] private Button _collectButton;

    private void Start()
    {
        _closePanelButton.onClick.AddListener(DestroyScreen);
        _closePanelBackgroundButton.onClick.AddListener(DestroyScreen);
        
        _collectButton.onClick.AddListener(CollectButtonClicked);
    }

    public void MakeButtonInteractable()
    {
        _collectButton.interactable = true;
    }
    
    public void MakeButtonUnInteractable()
    {
        _collectButton.interactable = false;
    }
    
    private void DestroyScreen()
    {
        _uiFactory.DestroyPlantInfoScreen();
    }

    private void CollectButtonClicked()
    {
        IsCollectButtonClicked?.Invoke();
        
        _uiFactory.DestroyPlantInfoScreen();
    }
}
