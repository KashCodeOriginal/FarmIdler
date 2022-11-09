using Zenject;
using Pathfinding;
using UnityEngine;
using KasherOriginal.Settings;
using System.Collections.Generic;
using UnityEngine.Events;

public class FarmerMovement : MonoBehaviour, IMovable
{
    [Inject]
    public void Construct(IBedInstancesWatcher bedInstancesWatcher, GameSettings gameSettings)
    {
        _bedInstancesWatcher = bedInstancesWatcher;
        _gameSettings = gameSettings;
    }

    public event UnityAction<GameObject> IsBedVisited;

    [SerializeField] private float _reachedPointDistance;

    private GameSettings _gameSettings;

    private Vector3 _homePosition;

    private IBedInstancesWatcher _bedInstancesWatcher;

    private GameObject _positionTarget;

    private List<Transform> _targets = new List<Transform>();

    private Transform _currentTarget;

    public bool IsTargetReached { get; private set; }


    public IReadOnlyList<Transform> MoveTargets
    {
        get => _targets;
    }

    private void Start()
    {
        _positionTarget = new GameObject();
        _positionTarget.name = "FarmerTarget";

        _bedInstancesWatcher.IsBedModified += BedWasModified;

        _homePosition = _gameSettings.PlayerSpawnPosition;
    }

    public void MoveToPoint(AIDestinationSetter aiDestinationSetter)
    {
        if (_targets.Count > 0 && _currentTarget == null)
        {
            _currentTarget = _targets[0];
            
            _positionTarget.transform.position = _currentTarget.position;
            
            aiDestinationSetter.target = _positionTarget.transform;
        }
        
        if (Vector3.Distance(gameObject.transform.position, _positionTarget.transform.position) < _reachedPointDistance)
        {
            IsBedVisited?.Invoke(_targets[0].gameObject);
            
            IsTargetReached = true;

            _targets.Remove(_targets[0]);

            _currentTarget = null;
        }
    }

    public void MoveToHome(AIDestinationSetter aiDestinationSetter)
    {
        _positionTarget.transform.position = _homePosition;
        
        _currentTarget = _positionTarget.transform;

        aiDestinationSetter.target = _currentTarget;
        
        if (Vector3.Distance(gameObject.transform.position, _positionTarget.transform.position) < _reachedPointDistance)
        {
            _currentTarget = null;
        }
    }

    public void AddMovingPoint(Transform point)
    {
        _targets.Add(point);
    }

    private void BedWasModified(Bed bed)
    {
        AddMovingPoint(bed.transform);
    }

    private void OnDisable()
    {
        _bedInstancesWatcher.IsBedModified -= BedWasModified;
    }
}