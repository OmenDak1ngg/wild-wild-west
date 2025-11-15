using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Animator _animator;

    private readonly string _attackedTrigger = "Attacked";

    private void OnEnable()
    {
        _userInput.Attacked += ShowAnimation;
    }

    private void OnDisable()
    {
        _userInput.Attacked -= ShowAnimation;
    }

    private void ShowAnimation()
    {
        _animator.SetTrigger(_attackedTrigger);
    }
}