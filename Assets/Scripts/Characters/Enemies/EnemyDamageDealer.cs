using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Player _player;
    private EnemyMover _mover;

    private void OnEnable()
    {
        _mover.ReachedTarget += DealDamageToPlayer;   
    }

    private void OnDisable()
    {
        _mover.ReachedTarget -= DealDamageToPlayer;
    }

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    public void DealDamageToPlayer()
    {
        _player.Health.TakeDamage(_damage);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
}
