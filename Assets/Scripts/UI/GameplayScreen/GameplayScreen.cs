using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private Slider _experienceSlider;
    [SerializeField] private TextMeshProUGUI _playerLevelText;
    
    [SerializeField] private TextMeshProUGUI _carrotAmountText;

    private FarmerExperience _farmerExperience;
    private FarmerInventory _farmerInventory;

    public void SetUp(FarmerExperience farmerExperience, FarmerInventory farmerInventory)
    {
        _farmerExperience = farmerExperience;
        _farmerInventory = farmerInventory;
        
        ChangeExperienceDisplayValue(0);
        ChangeLevelDisplayValue(0);
        
        _farmerExperience.IsExperienceValueChanged += ChangeExperienceDisplayValue;
        _farmerExperience.IsLevelValueChanged += ChangeLevelDisplayValue;

        _farmerInventory.IsCarrotAmountChanged += ChangeCarrotAmountValue;
    }
    
    private void ChangeExperienceDisplayValue(int experienceValue)
    {
        _experienceSlider.value = experienceValue;
    }

    private void ChangeLevelDisplayValue(int levelValue)
    {
        _playerLevelText.text = levelValue.ToString();
    }
    
    private void ChangeCarrotAmountValue(int carrotAmount)
    {
        _carrotAmountText.text = carrotAmount.ToString();
    }

    private void OnDisable()
    {
        _farmerExperience.IsExperienceValueChanged -= ChangeExperienceDisplayValue;
        _farmerExperience.IsLevelValueChanged -= ChangeLevelDisplayValue;
        
        _farmerInventory.IsCarrotAmountChanged -= ChangeCarrotAmountValue;
    }
}
