using UnityEngine;

namespace KasherOriginal.Settings
{
    [CreateAssetMenu(fileName = "PlantsSettings", menuName = "Settings/PlantsSettings")]
    public class PlantSettings : BaseSettings
    {
        [SerializeField] private Sprite _carrotImage;
        [SerializeField] private Sprite _treeImage;
        [SerializeField] private Sprite _grassImage;
        
        [SerializeField] private int _carrotCollectExperience;
        [SerializeField] private int _grassCollectExperience;
        
        public Sprite CarrotImage => _carrotImage;
        public Sprite TreeImage => _treeImage;
        public Sprite GrassImage => _grassImage;
        
        public int CarrotCollectExperience => _carrotCollectExperience;
        public int GrassCollectExperience => _grassCollectExperience;
    }
}