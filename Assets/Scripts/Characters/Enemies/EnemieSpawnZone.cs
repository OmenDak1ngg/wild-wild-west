using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemieSpawnZone : MonoBehaviour
{
    private Collider[] _colliders;
    private int _colliderIndex;

    private void Awake()
    {
        _colliders = GetComponents<Collider>();
    }

    public Vector3 GetRandomPoint()
    {
        _colliderIndex = Random.Range(0,_colliders.Length);
        Collider randomCollider = _colliders[_colliderIndex];   

        return new Vector3(
            Random.Range(randomCollider.bounds.min.x, randomCollider.bounds.max.x),
            Random.Range(randomCollider.bounds.min.y, randomCollider.bounds.max.y),
            Random.Range(randomCollider.bounds.min.z, randomCollider.bounds.max.z));
    }
}
