using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;
    [SerializeField] private float _zMin;
    [SerializeField] private float _zMax;

    [SerializeField] private float _speed;

    [SerializeField] private bool _isCameraMoving;

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
            var mousePosition = Input.mousePosition;

            mousePosition.z = 10f;
            
            _startPos = _camera.ScreenToWorldPoint(mousePosition);
        }
        
        else if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;

            mousePosition.z = 10f;
            
            var touchPosition = _camera.ScreenToWorldPoint(mousePosition);

            float posX = touchPosition.x - _startPos.x;
            float posZ = touchPosition.y - _startPos.y;

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