using System;
using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Transform _targetTransform;
    private float _treshold = 1f;
    private Coroutine _coroutine;

    public event Action ReachedTarget;

    private void Update()
    {
        if(_coroutine == null)
            _coroutine = StartCoroutine(MoveToTarget(_targetTransform.position));
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        while (Vector3.SqrMagnitude(transform.position - _targetTransform.position) > _treshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _moveSpeed * Time.deltaTime);
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