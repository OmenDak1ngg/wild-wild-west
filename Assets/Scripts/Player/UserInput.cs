﻿using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly string Vertical = "Vertical";
    private readonly string Horizontal = "Horizontal";
    private readonly KeyCode ShootKey = KeyCode.Mouse0;

    private float _verticalDirection;
    private float _horizontalDirection;

    public event Action<Vector3> Moved;
    public event Action<Vector3> Rotated;
    public event Action Shooted;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _verticalDirection = Input.GetAxis(Vertical);
        _horizontalDirection = Input.GetAxis(Horizontal);

        if (_verticalDirection != 0 || _horizontalDirection != 0)
        {
            Moved?.Invoke(new Vector3(_horizontalDirection, 0, _verticalDirection));
            Rotated?.Invoke(new Vector3(_horizontalDirection, 0, _verticalDirection));
        }

        if (Input.GetKeyDown(ShootKey))
        {
            Shooted?.Invoke();
        }
    }
}