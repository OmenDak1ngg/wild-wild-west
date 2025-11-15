using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class ShootAnimation : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Transform _shootCenter;

    private Vector3 _shootTarget;
    private float _laserDuration = 0.1f;
    private float _laserLength;
    private WaitForSeconds _waitDureation;
    private int _halfDivider = 2;
    private Gun _gun;

    private void OnEnable()
    {
        _userInput.Attacked += OnShoot;
    }

    private void OnDisable()
    {
        _userInput.Attacked -= OnShoot;
    }

    private void Awake()
    {
        _waitDureation = new WaitForSeconds(_laserDuration);
        _gun = GetComponent<Gun>();
        _laserLength = _gun.ShootLength;
        _lineRenderer.enabled = false;
        _shootTarget = new Vector3(Screen.width / _halfDivider, Screen.height / _halfDivider, 0);
    }

    private void OnShoot()
    {
        StartCoroutine(ShowLaser());
    }

    private IEnumerator ShowLaser()
    {
        _lineRenderer.enabled = true;
        Vector3 laserDirection = _shootTarget - _shootCenter.position;
        _lineRenderer.SetPosition(0,_shootCenter.position);

        Ray ray = Camera.main.ScreenPointToRay(_shootTarget);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _laserLength))
        {
            _lineRenderer.SetPosition(1,hit.point);
        }
        else
        {
            Vector3 endPoint = _shootCenter.position + laserDirection * _laserLength;
            _lineRenderer.SetPosition(1,endPoint);
        }

        yield return _waitDureation;

        _lineRenderer.enabled = false;
    }
}
