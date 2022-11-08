using Zenject;
using UnityEngine;
using UnityEngine.UI;
using KasherOriginal.Factories.UIFactory;

public class PlantInfoScreen : MonoBehaviour
{
    [Inject]
    public void Construct(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }

    private IUIFactory _uiFactory;
    
    [SerializeField] private Button _closePanelButton;
    [SerializeField] private Button _closePanelBackgroundButton;

    private void Start()
    {
        _closePanelButton.onClick.AddListener(DestroyScreen);
        _closePanelBackgroundButton.onClick.AddListener(DestroyScreen);
    }
    
    private void DestroyScreen()
    {
        _uiFactory.DestroyPlantInfoScreen();
    }
}
