using UnityEngine;

[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour
{
    [SerializeField] private Health _health;

    public Health Health => _health;
}
