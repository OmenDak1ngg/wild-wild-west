using UnityEngine;

[RequireComponent(typeof(EnemyDamageDealer))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : Character
{
    private EnemyMover _mover;
    private EnemyDamageDealer _damageDealer;

    private void Awake()
    {
        _damageDealer = GetComponent<EnemyDamageDealer>();
        _mover = GetComponent<EnemyMover>();
    }

    public void SetupOnCreate(Player player)
    {
        _mover.SetTargetPosition(player.transform);
        _damageDealer.SetPlayer(player);
    }
}
