using System.Collections;
using UnityEngine;

public class CameraLooker : MonoBehaviour
{
    [SerializeField] private Transform LookPoint;
    private void Update()
    {
        transform.LookAt(LookPoint);
    }
}