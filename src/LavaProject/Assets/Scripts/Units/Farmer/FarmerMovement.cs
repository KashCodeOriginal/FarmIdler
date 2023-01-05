using System;
using System.Collections.Generic;
using System.Linq;
using Data.Dynamic;
using Data.Dynamic.PlayerData;
using Data.Extensions;
using Data.Settings;
using Pathfinding;
using Services.PersistentProgress;
using Services.SaveLoad;
using Services.Watchers;
using Units.Farmer.Model;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Units.Farmer
{
    public class FarmerMovement : MonoBehaviour, IMovable, IProgressSavable, IProgressLoadable
    {
        [Inject]
        public void Construct(IBedInteractInstancesWatcher bedInteractInstancesWatcher, GameSettings gameSettings, ISaveLoadService saveLoadService)
        {
            _bedInteractInstancesWatcher = bedInteractInstancesWatcher;
            _gameSettings = gameSettings;
            _saveLoadService = saveLoadService;
        }

        public event UnityAction<GameObject> IsBedVisited;

        [SerializeField] private float _reachedPointDistance;

        private GameSettings _gameSettings;

        private Vector3 _homePosition;

        private IBedInteractInstancesWatcher _bedInteractInstancesWatcher;
        private ISaveLoadService _saveLoadService;

        private GameObject _positionTarget;

        private List<Transform> _targets = new List<Transform>();

        private Transform _currentTarget;

        public bool IsTargetReached { get; private set; }
        public bool IsHomeReached { get; private set; }


        public IReadOnlyList<Transform> MoveTargets
        {
            get => _targets;
        }

        private void Start()
        {
            _positionTarget = new GameObject
            {
                name = "FarmerTarget"
            };

            _bedInteractInstancesWatcher.IsBedModified += BedInteractWasModified;

            _homePosition = _gameSettings.PlayerSpawnPosition;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                _saveLoadService.SaveProgress();
            }
        }

        public void MoveToPoint(AIDestinationSetter aiDestinationSetter)
        {
            IsHomeReached = false;
        
            if (_targets.Count > 0)
            {
                _currentTarget = _targets.FirstOrDefault();

                if (_currentTarget != null)
                {
                    _positionTarget.transform.position = _currentTarget.position;
                }

                aiDestinationSetter.target = _positionTarget.transform;
            }
        
            if (Vector3.Distance(gameObject.transform.position, _positionTarget.transform.position) < _reachedPointDistance)
            {
                IsBedVisited?.Invoke(_targets.FirstOrDefault()?.gameObject);
            
                IsTargetReached = true;

                _targets.Remove(_targets.FirstOrDefault());

                _currentTarget = null;
            }
        }

        public void MoveToHome(AIDestinationSetter aiDestinationSetter)
        {
            _positionTarget.transform.position = _homePosition;
        
            _currentTarget = _positionTarget.transform;

            aiDestinationSetter.target = _currentTarget;
        
            if (Vector3.Distance(gameObject.transform.position, _homePosition) < _reachedPointDistance)
            {
                _currentTarget = null;
                IsHomeReached = true;
            }
        }

        public void AddMovingPoint(Transform point)
        {
            _targets.Add(point);
        }

        private void BedInteractWasModified(Bed.Bed bed)
        {
            AddMovingPoint(bed.transform);
        }

        private void OnDisable()
        {
            _bedInteractInstancesWatcher.IsBedModified -= BedInteractWasModified;
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            var position = transform.position;
            playerProgress.WorldData.PositionOnLevel = new PositionOnLevel(position.AsVectorData());
        }


        public void LoadProgress(PlayerProgress playerProgress)
        {
            var position = playerProgress.WorldData.PositionOnLevel.Position;

            if (position != null)
            {
                WarpPosition(position);
            }
        }

        private void WarpPosition(Vector3Data position)
        {
            transform.position = position.AsVector3().AddHeight(0.5f);
        }
    }
}