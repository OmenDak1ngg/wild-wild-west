using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private Vector3 _attackSize;
    [SerializeField] private Transform _attackCenter;

    private int _halfDivider = 2;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Matrix4x4 originalMatrix = Gizmos.matrix;
        Gizmos.matrix = _attackCenter.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, _attackSize);
        Gizmos.matrix = originalMatrix;
    }

    protected override void Attack()
    {
        Collider[] colliders = Physics.OverlapBox(_attackCenter.position, _attackSize / _halfDivider, _attackCenter.rotation);

        foreach(Collider collider in colliders)
        {
            if(collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Health.TakeDamage(Damage);
            }
        }
    }
}
