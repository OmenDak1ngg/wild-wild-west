using System;
using System.Collections;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private int _startAmount;

    private int _amount;

    public event Action Dead;

    private void Awake()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        _amount = _startAmount;
    }

    public void TakeDamage(int damage)
    {
        if(_amount < damage)
        {
            _amount = 0;
        }
        else
        {
            _amount -= damage;
        }

        if(_amount <= 0)
        {
            Dead?.Invoke();
        }
    }
}