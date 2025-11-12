using System.Collections;
using UnityEngine;


public class EnemyWaveStarter : MonoBehaviour
{
    [SerializeField] private int _minEnemies = 3;
    [SerializeField] private int _maxEnemies = 5;

    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private WaveCounter _waveCounter;

    private int _countOfEnemies;

    private void Awake()
    {
        _countOfEnemies = Random.Range(_minEnemies, _maxEnemies);
    }

    private void Start()
    {
        StartWave(_countOfEnemies);
    }

    private void StartWave(int enemiesCount)
    {
        _spawner.SpawnEnemies(enemiesCount);
        _waveCounter.IncreaseCount();
    }
}