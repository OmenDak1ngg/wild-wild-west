using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
 /*   [SerializeField] private LayerMask _shootableLayer;

    [SerializeField] private float _shootLength = 1000f;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private int _damage = 5;

    private int _halfDivider = 2;

    public float ShootLength => _shootLength;

    private void OnEnable()
    {
        _userInput.Shooted += Shoot;
    }

    private void OnDisable()
    {
        _userInput.Shooted -= Shoot;
    }

    private void Shoot()
    {
        Vector3 shootCenter = new Vector3(Screen.width / _halfDivider, Screen.height / _halfDivider, 0);

        Ray ray = Camera.main.ScreenPointToRay(shootCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _shootLength,_shootableLayer))
        {
            Debug.Log(hit.transform.name);
            if(hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Health.TakeDamage(_damage);
            }
        }
    }*/
}
