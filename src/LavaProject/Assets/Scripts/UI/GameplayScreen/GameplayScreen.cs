using System;
using Services.PersistentProgress;
using TMPro;
using Units.Farmer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayScreen
{
    public class GameplayScreen : MonoBehaviour
    {
        [SerializeField] private Slider _experienceSlider;
        [SerializeField] private TextMeshProUGUI _playerLevelText;
    
        [SerializeField] private TextMeshProUGUI _carrotAmountText;

        private IPersistentProgressService _persistentProgressService;

        public void SetUp(IPersistentProgressService persistentProgressService)
        {
            _persistentProgressService = persistentProgressService;

            _persistentProgressService.PlayerProgress.PlayerData.IsExperienceValueChanged += ChangeExperienceDisplayValue;
            _persistentProgressService.PlayerProgress.PlayerData.IsLevelValueChanged += ChangeLevelDisplayValue;

            _persistentProgressService.PlayerProgress.LootData.IsAmountChanged += ChangeCarrotAmountValue;
            
            UpdateDisplayedInfo();
        }

        private void UpdateDisplayedInfo()
        {
            ChangeCarrotAmountValue();

            ChangeExperienceDisplayValue();
            ChangeLevelDisplayValue();
        }

        private void ChangeExperienceDisplayValue()
        {
            _experienceSlider.value = _persistentProgressService.PlayerProgress.PlayerData.Experience;
        }

        private void ChangeLevelDisplayValue()
        {
            _playerLevelText.text = _persistentProgressService.PlayerProgress.PlayerData.Level.ToString();
        }
    
        private void ChangeCarrotAmountValue()
        {
            _carrotAmountText.text = _persistentProgressService.PlayerProgress.LootData.Collected.ToString();
        }

        private void OnDisable()
        {
            _persistentProgressService.PlayerProgress.PlayerData.IsExperienceValueChanged -= ChangeExperienceDisplayValue;
            _persistentProgressService.PlayerProgress.PlayerData.IsLevelValueChanged -= ChangeLevelDisplayValue;
        
            _persistentProgressService.PlayerProgress.LootData.IsAmountChanged -= ChangeCarrotAmountValue;
        }
    }
}
