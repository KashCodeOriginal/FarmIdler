using UnityEngine;
using System.Collections.Generic;

public class PlantsGrowing : MonoBehaviour
{
    [SerializeField] private float _timeBetweenStages;
    
    private List<GameObject> _stages = new List<GameObject>();
    
    private float _currentStageTime = 0;
    
    private int _currentStage = 0;
    
    public int CurrentStage => _currentStage;

    public float CurrentStageTime => _currentStageTime;

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _stages.Add(gameObject.transform.GetChild(i).gameObject);
        }
        
        SetStage(_currentStage);
    }
    
    private void SetStage(int stage)
    {
        if (stage == 0)
        {
            _stages[stage].SetActive(true);
            return;
        }
        
        _stages[stage - 1].SetActive(false);
        _stages[stage].SetActive(true);
    }

    private void Update()
    {
        if (_currentStage < _stages.Count - 1)
        {
            _currentStageTime += Time.deltaTime;

            if (_currentStageTime >= _timeBetweenStages)
            {
                _currentStageTime = 0;
                _currentStage++;
                SetStage(_currentStage);
            }
        }
    }
}
