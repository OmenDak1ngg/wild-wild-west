using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float _shootLength = 1000f;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private LayerMask _shootLayerMask;

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
        Vector3 shootCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = Camera.main.ScreenPointToRay(shootCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _shootLength, _shootLayerMask))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
