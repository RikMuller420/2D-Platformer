using UnityEngine;

public class PlayerMover : CreatureMover
{
    [SerializeField] private PlayerGroundChecker _groundChecker;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 12f;

    public void Move(float moveInput)
    {
        float velocityX = moveInput * _moveSpeed;
        MoveHorizontal(velocityX);
    }

    public void TryJump()
    {
        if (_groundChecker.IsGrounded)
        {
            Rigidbody.linearVelocityY = _jumpForce;
        }
    }
}
