using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;
    [SerializeField] private float _zMin;
    [SerializeField] private float _zMax;

    [SerializeField] private float _speed;
    
    private Vector3 _startPos;

    private float _targetPosX;
    private float _targetPosZ;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            var cameraPos = _camera.ScreenToWorldPoint(Input.mousePosition);

            float posX = cameraPos.x - _startPos.x;
            float posZ = cameraPos.z - _startPos.z;

            var position = transform.position;
            
            _targetPosX = Mathf.Clamp(position.x - posX, _xMin, _xMax);
            _targetPosZ = Mathf.Clamp(position.z - posZ, _zMin, _zMax);
        }

        var currentPosition = transform.position;
        
        currentPosition = new Vector3(
            Mathf.Lerp(currentPosition.x, _targetPosX, _speed * Time.deltaTime), 
            currentPosition.y, 
            Mathf.Lerp(currentPosition.z, _targetPosZ, _speed * Time.deltaTime));

        transform.position = currentPosition;
    }
}