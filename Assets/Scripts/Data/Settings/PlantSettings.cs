using UnityEngine;

namespace KasherOriginal.Settings
{
    [CreateAssetMenu(fileName = "PlantsSettings", menuName = "Settings/PlantsSettings")]
    public class PlantSettings : BaseSettings
    {
        [SerializeField] private Sprite _carrotImage;
        [SerializeField] private Sprite _treeImage;
        [SerializeField] private Sprite _grassImage;
        
        public Sprite CarrotImage => _carrotImage;
        public Sprite TreeImage => _treeImage;
        public Sprite GrassImage => _grassImage;
    }
}