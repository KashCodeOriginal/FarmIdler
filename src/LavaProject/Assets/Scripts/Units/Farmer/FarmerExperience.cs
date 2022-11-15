using UnityEngine;
using UnityEngine.Events;

public class FarmerExperience : MonoBehaviour
{
    public event UnityAction<int> IsExperienceValueChanged;
    public event UnityAction<int> IsLevelValueChanged;

    private int _experienceValue;
    private int _level;

    private int _maxExperienceForLevel;

    private void Start()
    {
        _experienceValue = 0;
        _level = 0;
        _maxExperienceForLevel = 100;
    }

    public void AddExperience(int increaseValue)
    {
        if (_experienceValue + increaseValue >= _maxExperienceForLevel)
        {
            var maxExperience = _maxExperienceForLevel - _experienceValue;
            _level++;
            _experienceValue = increaseValue - maxExperience;
            
            IsExperienceValueChanged?.Invoke(_experienceValue);
            IsLevelValueChanged?.Invoke(_level);
        }
        else
        {
            _experienceValue += increaseValue;
            IsExperienceValueChanged?.Invoke(_experienceValue);
        }
    }
}
