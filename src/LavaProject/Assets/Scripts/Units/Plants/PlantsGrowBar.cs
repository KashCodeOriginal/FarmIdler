using TMPro;
using UnityEngine;

public class PlantsGrowBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _estimateTime;

    [SerializeField] private Transform _canvas;
    
    [SerializeField] private PlantsGrowing _plantsGrowing;
    
    [SerializeField] private GameObject _canvasInstance;

    private float _totalGrowingTime;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        _totalGrowingTime = _plantsGrowing.TimeBetweenStages * (_plantsGrowing.Stages.Count - 1);
    }

    private void Update()
    {
        _totalGrowingTime -= 1 * Time.deltaTime;

        _estimateTime.text = _totalGrowingTime.ToString("0");

        if (_totalGrowingTime <= 0)
        {
            Destroy(_canvasInstance);
        }
    }

    private void LateUpdate()
    {
        _canvas.LookAt(_camera.transform);
    }
}
