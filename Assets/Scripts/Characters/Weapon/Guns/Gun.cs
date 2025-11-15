using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private float _shootLength;

    private int _halfDivider = 2;

    public float ShootLength => _shootLength;

    protected override void Attack()
    {
        Vector3 shootCenter = new Vector3(Screen.width / _halfDivider, Screen.height / _halfDivider, 0);

        Ray ray = Camera.main.ScreenPointToRay(shootCenter);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _shootLength, AttackableLayer))
        {
            Debug.Log(hit.collider.name);

            if(hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Health.TakeDamage(Damage);
            }
        }
    }
}