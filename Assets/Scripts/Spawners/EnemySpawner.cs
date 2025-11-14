using System;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private EnemieSpawnZone _spawnZone;
    [SerializeField] private Player _player;

    private List<Enemy> _enemies;

    public event Action Getted;
    public event Action Released;

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Health.Dead -= () => Release(enemy);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _enemies = new List<Enemy>();
    }

    protected override Enemy OnInstantiate()
    {
        Enemy enemy = base.OnInstantiate();
        enemy.SetupOnCreate(_player);
        enemy.Health.Dead += () => Release(enemy);
        _enemies.Add(enemy);
        enemy.transform.parent = transform;

        return enemy;
    }

    protected override void OnGet(Enemy pooledObject)
    {
        pooledObject.Health.ResetHealth();
        base.OnGet(pooledObject);
        pooledObject.transform.position = _spawnZone.GetRandomPoint();
        Getted?.Invoke();
    }

    protected override void OnRelease(Enemy pooledObject)
    {
        base.OnRelease(pooledObject);
        Debug.Log("Released");
        Released?.Invoke();
    }

    public void SpawnEnemies(int countEnemies)
    {
        for (int i = 0; i < countEnemies; i++)
        {
            Pool.Get();
        }
    }
}
