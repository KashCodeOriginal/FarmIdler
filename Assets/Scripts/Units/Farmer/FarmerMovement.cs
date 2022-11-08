using System;
using Zenject;
using Pathfinding;
using UnityEngine;
using System.Collections.Generic;

public class FarmerMovement : MonoBehaviour, IMovable
{
    [Inject]
    public void Construct(IBedInstancesWatcher bedInstancesWatcher)
    {
        _bedInstancesWatcher = bedInstancesWatcher;
    }
    
    [SerializeField] private float _reachedPointDistance;

    private IBedInstancesWatcher _bedInstancesWatcher;

    private GameObject _positionTarget;

    private List<Transform> _targets = new List<Transform>();

    private Transform _currentTarget;

    public IReadOnlyList<Transform> MoveTargets
    {
        get => _targets;
    }

    private void Start()
    {
        _positionTarget = new GameObject();
        _positionTarget.name = "FarmerTarget";

        _bedInstancesWatcher.IsBedModified += BedWasModified;
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
            Debug.Log("Collided");

            _targets.Remove(_targets[0]);

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