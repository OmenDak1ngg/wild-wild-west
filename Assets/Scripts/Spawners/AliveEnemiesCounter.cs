using System;
using System.Collections;
using UnityEngine;


public class AliveEnemiesCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private int _count;

    public event Action NoEnemiesLeft;

    private void OnEnable()
    {
        _enemySpawner.Getted += IncreaseCount;
        _enemySpawner.Released -= DecreaseCount;
    }

    private void OnDisable()
    {
        _enemySpawner.Getted -= IncreaseCount;
        _enemySpawner.Released -= DecreaseCount;
    }

    private void Awake()
    {
        _count = 0;
    }

    private void IncreaseCount()
    {
        _count++;
    }

    private void DecreaseCount()
    {
        _count--;
        
        if(_count == 0 )
            NoEnemiesLeft?.Invoke();
    }
}