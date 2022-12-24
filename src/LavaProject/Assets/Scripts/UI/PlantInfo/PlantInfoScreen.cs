using Infrastructure.Factory.UIFactory;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace UI.PlantInfo
{
    public class PlantInfoScreen : MonoBehaviour
    {
        [Inject]
        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public event UnityAction IsCollectButtonClicked;

        [SerializeField] private Button _closePanelButton;
        [SerializeField] private Button _closePanelBackgroundButton;
    
        [SerializeField] private TextMeshProUGUI _infoPanelPlantName;
    
        [SerializeField] private Button _collectButton;
        [SerializeField] private GameObject _collectButtonInstance;

        [SerializeField] private Image _plantImage;
    
        private IUIFactory _uiFactory;


        private void Start()
        {
            _closePanelButton.onClick.AddListener(DestroyScreen);
            _closePanelBackgroundButton.onClick.AddListener(DestroyScreen);
        
            _collectButton.onClick.AddListener(CollectButtonClicked);
        }

        public void MakeButtonInteractable()
        {
            _collectButtonInstance.SetActive(true);
        }
    
        public void MakeButtonUnInteractable()
        {
            _collectButtonInstance.SetActive(false);
        }

        public void SetPlantInfo(string plantName, Sprite image)
        {
            _infoPanelPlantName.text = plantName;
            _plantImage.sprite = image;
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
}
