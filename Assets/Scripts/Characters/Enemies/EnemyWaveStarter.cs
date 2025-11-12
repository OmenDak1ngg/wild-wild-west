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
    private int _countOfEnemies;

    private void OnEnable()
    {
        _aliveEnemiesCount.NoEnemiesLeft += StartCoroutineWave;
    }

    private void OnDisable()
    {
        _aliveEnemiesCount.NoEnemiesLeft -= StartCoroutineWave;
    }

    private void Awake()
    {
        _waitBetweenWaves = new WaitForSeconds(_delayBetweenWaves);
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

    private void StartCoroutineWave()
    {
        StartCoroutine(StartWaveWithDelay());
    }

    private IEnumerator StartWaveWithDelay()
    {
        yield return _waitBetweenWaves;
        StartWave(_countOfEnemies);
    }
}