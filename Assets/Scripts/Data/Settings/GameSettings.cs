using UnityEngine;

namespace KasherOriginal.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
    public class GameSettings : BaseSettings
    {
        [SerializeField] private Vector3 _cameraInstancePosition;
        [SerializeField] private Quaternion _cameraInstanceRotation;
        
        [Space(5f)]
        
        [SerializeField] private Vector3 _baseMapPosition;
        
        
        [Space(5f)]

        [SerializeField] private int _targetFPS;

        public Vector3 CameraInstancePosition => _cameraInstancePosition;
        public Quaternion CameraInstanceRotation => _cameraInstanceRotation;
        public Vector3 BaseMapPosition => _baseMapPosition;
        
        private void OnEnable()
        {
            Application.targetFrameRate = _targetFPS;
        }
    }
}