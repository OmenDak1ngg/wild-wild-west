using UnityEngine;

[RequireComponent(typeof(EnemyDamageDealer))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : Character
{
    [SerializeField] private int _shootableLayer = 6;

    private EnemyMover _mover;
    private EnemyDamageDealer _damageDealer;

    private void Awake()
    {
        SetShootableLayer();
        _damageDealer = GetComponent<EnemyDamageDealer>();
        _mover = GetComponent<EnemyMover>();
    }

    protected virtual void SetShootableLayer()
    {
        gameObject.layer = _shootableLayer;
    }

    public void SetupOnCreate(Player player)
    {
        _mover.SetTargetPosition(player.transform);
        _damageDealer.SetPlayer(player);
    }
}
