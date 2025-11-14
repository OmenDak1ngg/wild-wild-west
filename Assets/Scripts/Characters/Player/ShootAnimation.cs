using System.Collections;
using UnityEngine;

public class ShootAnimation : MonoBehaviour
{
    private Vector3 _shootCenter;

    private void Awake()
    {
        _shootCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    private void OnShoot()
    {

    }
}
