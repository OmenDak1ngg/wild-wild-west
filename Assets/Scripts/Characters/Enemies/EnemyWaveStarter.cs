using System.Collections;
using UnityEngine;


public class EnemyWaveStarter : MonoBehaviour
{
    [SerializeField] private int _countOfEnemies;
    [SerializeField] private EnemySpawner _spawner;

    private void Start()
    {
        _spawner.SpawnEnemies(_countOfEnemies);
    }
}