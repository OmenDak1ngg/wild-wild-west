using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Weapon _mainWeapon;
    [SerializeField] private Weapon _secondaryWeapon;

    [SerializeField] private UserInput _userInput;

    private Weapon _currentWeapon;

    private void OnEnable()
    {
        _userInput.Switched += SwitchWeapon;
    }

    private void OnDisable()
    {
        _userInput.Switched -= SwitchWeapon;
    }

    private void Awake()
    {
        _currentWeapon = _mainWeapon;
        _mainWeapon.gameObject.SetActive(true);
        _secondaryWeapon.gameObject.SetActive(false);
    }

    private void SwitchWeapon()
    {
        if (_currentWeapon == _mainWeapon)
        {
            _mainWeapon.gameObject.SetActive(false);
            _secondaryWeapon.gameObject.SetActive(true);
            _currentWeapon = _secondaryWeapon;
        }
        else
        {
            _mainWeapon.gameObject.SetActive(true);
            _secondaryWeapon.gameObject.SetActive(false);
            _currentWeapon = _mainWeapon;
        }
    }
}