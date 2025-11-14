using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private NavMeshAgent _agent;

    private Transform _targetTransform;
    private float _treshold = 1f;
    private Coroutine _coroutine;

    public event Action ReachedTarget;

    private void Awake()
    {
        _agent.speed = _moveSpeed;
    }

    private void Update()
    {
        if(_coroutine == null)
            _coroutine = StartCoroutine(MoveToTarget(_targetTransform.position));
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        while (Vector3.SqrMagnitude(transform.position - _targetTransform.position) > _treshold)
        {
            _agent.SetDestination(targetPosition);

            yield return null;
        }

        ReachedTarget?.Invoke();
        _coroutine = null;
    }

    public void SetTargetPosition(Transform transform)
    {
        _targetTransform = transform;
    }
}