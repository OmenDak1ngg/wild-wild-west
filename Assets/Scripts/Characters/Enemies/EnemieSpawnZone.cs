using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemieSpawnZone : MonoBehaviour
{
    [SerializeField] private float _lengthSizeOfCollider;
    [SerializeField] private BoxCollider[] _verticalColliders;
    [SerializeField] private BoxCollider[] _horizontalColliders;

    private int _halfDivider = 2;
    private int _colldidersPairCount = 2;
    private int _colliderIndex;
    private List<BoxCollider> _colliders;

    private void Awake()
    {
        _colliders = new List<BoxCollider>();
        _colliders.AddRange(_verticalColliders);
        _colliders.AddRange(_horizontalColliders);
    }

    [ContextMenu("ResizeColliderLength")]
    private void ResizeColliders()
    {
        BoxCollider verticalCollider;
        BoxCollider horizontalCollider;

        for (int i = 0; i < _colldidersPairCount; i++)
        {
            if (_lengthSizeOfCollider < 0)
                _lengthSizeOfCollider *= -1;

            verticalCollider = _verticalColliders[i];
            horizontalCollider = _horizontalColliders[i];

            verticalCollider.size = new Vector3(verticalCollider.size.x, verticalCollider.size.y, _lengthSizeOfCollider);
            horizontalCollider.size = new Vector3(_lengthSizeOfCollider, horizontalCollider.size.y, horizontalCollider.size.z);


            if (i > 0)
                _lengthSizeOfCollider *= -1;

            verticalCollider.center = new Vector3(_lengthSizeOfCollider / _halfDivider, verticalCollider.center.y, verticalCollider.center.z);
            horizontalCollider.center = new Vector3(horizontalCollider.center.x, verticalCollider.center.y, _lengthSizeOfCollider / _halfDivider);

            _verticalColliders[i] = verticalCollider;
            _horizontalColliders[i] = horizontalCollider;
        }

    }

    public Vector3 GetRandomPoint()
    {
        _colliderIndex = Random.Range(0,_colliders.Count);
        Collider randomCollider = _colliders[_colliderIndex];   

        return new Vector3(
            Random.Range(randomCollider.bounds.min.x, randomCollider.bounds.max.x),
            Random.Range(randomCollider.bounds.min.y, randomCollider.bounds.max.y),
            Random.Range(randomCollider.bounds.min.z, randomCollider.bounds.max.z));
    }
}
