using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerGroundChecker))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerGroundChecker _playerGroundChecker;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 12f;

    private void OnEnable()
    {
        _inputHandler.HorizontalMoveInputAction += Move;
        _inputHandler.JumpInputAction += Jump;
    }

    private void OnDisable()
    {
        _inputHandler.HorizontalMoveInputAction -= Move;
        _inputHandler.JumpInputAction -= Jump;
    }

    private void Move(float moveInput)
    {
        _rigidbody.linearVelocityX = moveInput * _moveSpeed;
    }

    private void Jump()
    {
        if (_playerGroundChecker.IsGrounded)
        {
            _rigidbody.linearVelocityY = _jumpForce;
        }
    }
}
