using System.Collections.Generic;
using UnityEngine;

namespace Units.Plants
{
    public class PlantsGrowing : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _stages = new List<GameObject>();
    
        private float _timeBetweenStages;

        private float _currentStageTime = 0;
    
        private int _currentStage = 0;

        private bool _canGrow = true;
    
        private bool _wasPlantGrown = false;

        public float TimeBetweenStages => _timeBetweenStages;

        public List<GameObject> Stages => _stages;
    
        public bool WasPlantGrown => _wasPlantGrown;

        public int CurrentStage => _currentStage;

        public float CurrentStageTime => _currentStageTime;

        private void Start()
        {
            _wasPlantGrown = false;
            SetStage(CurrentStage);
        }

        public void SetStageTime(int time)
        {
            _timeBetweenStages = time;
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
            if (_canGrow)
            {
                if (CurrentStage < _stages.Count - 1)
                {
                    _currentStageTime = CurrentStageTime + Time.deltaTime;

                    if (CurrentStageTime >= _timeBetweenStages)
                    {
                        _currentStageTime = 0;
                        _currentStage = CurrentStage + 1;
                        SetStage(CurrentStage);
                    }
                }
                else
                {
                    _canGrow = false;
                    _wasPlantGrown = true;
                }
            }
        
        }
    }
}
