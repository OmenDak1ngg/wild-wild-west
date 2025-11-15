using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    
    [SerializeField] protected LayerMask AttackableLayer;
    [SerializeField] protected int Damage;

    protected virtual void OnEnable()
    {
        _userInput.Attacked += Attack;
    }

    protected virtual void OnDisable()
    {
        _userInput.Attacked -= Attack;
    }

    protected abstract void Attack();
}