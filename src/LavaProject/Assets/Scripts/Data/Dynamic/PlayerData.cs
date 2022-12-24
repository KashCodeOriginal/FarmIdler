using System;
using UnityEngine.Events;

namespace Data.Dynamic
{
    [Serializable]
    public class PlayerData
    {
        public event UnityAction IsExperienceValueChanged;
        public event UnityAction IsLevelValueChanged;

        public int Experience;
        public int Level;
        public int MaxExperienceForLevel;

        public void AddExperience(int experience)
        {
            if (Experience + experience >= MaxExperienceForLevel)
            {
                var maxExperience = MaxExperienceForLevel - Experience;
                Level++;
                Experience = experience - maxExperience;
            
                IsExperienceValueChanged?.Invoke();
                IsLevelValueChanged?.Invoke();
            }
            else
            {
                Experience += experience;
                IsExperienceValueChanged?.Invoke();
            }
        }
    }
}