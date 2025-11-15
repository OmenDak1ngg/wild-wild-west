using System;
using System.Collections;
using UnityEngine;

public class EnemyWaveStarter : MonoBehaviour
{
    [SerializeField] private int _minEnemies = 3;
    [SerializeField] private int _maxEnemies = 5;
    [SerializeField] private float _delayBetweenWaves;

    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private WaveCounter _waveCounter;
    [SerializeField] private AliveEnemiesCounter _aliveEnemiesCount;

    private WaitForSeconds _waitBetweenWaves;

    public float DelayBetweenWaves => _delayBetweenWaves;

    public event Action DelayStarted;

    private void OnEnable()
    {
        _aliveEnemiesCount.NoEnemiesLeft += StartWaveCoroutine;
    }

    private void OnDisable()
    {
        _aliveEnemiesCount.NoEnemiesLeft -= StartWaveCoroutine;
    }

    private void Awake()
    {
        _waitBetweenWaves = new WaitForSeconds(_delayBetweenWaves);
    }

    private void Start()
    {
        StartWaveCoroutine();
    }

    private void StartWaveCoroutine()
    {
        StartCoroutine(StartWaveWithDelay());
    }

    private IEnumerator StartWaveWithDelay()
    {
        DelayStarted?.Invoke(); 

        yield return _waitBetweenWaves;

        int countOfEnemies = UnityEngine.Random.Range(_minEnemies, _maxEnemies);
        _spawner.SpawnEnemies(countOfEnemies);
        _waveCounter.IncreaseCount();
    }
}