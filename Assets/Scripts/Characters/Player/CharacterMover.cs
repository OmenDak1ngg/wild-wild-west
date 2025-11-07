using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private UserInput _userInput;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _gravityForce;
    [SerializeField] private Transform _cameraTransform;

    private float _currentGravityForce;

    private void OnEnable()
    {
        _userInput.Moved += Move;
    }

    private void OnDisable()
    {
        _userInput.Moved -= Move;
    }

    private void Awake()
    {
        _currentGravityForce = 0f;
    }

    private void Update()
    {
        Rotate();
        HandleGravity();
    }

    private void Move(Vector3 moveDirection)
    {
        Vector3 cameraForward = _cameraTransform.forward;
        Vector3 cameraRight = _cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 relativeMove = cameraForward.normalized * moveDirection.z + cameraRight.normalized * moveDirection.x;

        relativeMove.y = _currentGravityForce;
        _characterController.Move(relativeMove * _moveSpeed * Time.deltaTime);
    }


    private void Rotate()
    {
        Vector3 lookDirection = _cameraTransform.forward;
        lookDirection.y = 0f;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.LookRotation(lookDirection),
            _rotateSpeed * Time.deltaTime
        );
    }

    private void HandleGravity()
    {
        if (_characterController.isGrounded == false)
        {
            _currentGravityForce -= _gravityForce * Time.deltaTime;
        }
        else
        {
            _currentGravityForce = 0;
        }
    }
}
