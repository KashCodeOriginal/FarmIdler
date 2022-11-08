using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlantChooseScreen : MonoBehaviour
{
    public event UnityAction<BedCellType> IsChooseButtonClicked;
    
    [SerializeField] private Button _carrotChooseButton;
    [SerializeField] private Button _treeChooseButton;
    [SerializeField] private Button _grassChooseButton;

    private void Start()
    {
        _carrotChooseButton.onClick.AddListener(delegate { IsChooseButtonClicked?.Invoke(BedCellType.Carrot); });
        _treeChooseButton.onClick.AddListener(delegate { IsChooseButtonClicked?.Invoke(BedCellType.Tree); });
        _grassChooseButton.onClick.AddListener(delegate { IsChooseButtonClicked?.Invoke(BedCellType.Grass); });
    }
}
