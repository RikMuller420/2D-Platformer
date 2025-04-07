using UnityEngine;

public class PlayerMover : CreatureMover
{
    [SerializeField] private LayerContactChecker _groundChecker;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 12f;

    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = Animator as PlayerAnimator;
    }

    public void Move(float moveInput)
    {
        float velocityX = moveInput * _moveSpeed;
        MoveHorizontal(velocityX);

        _playerAnimator.UpdateMoveAnimation(velocityX);
        _playerAnimator.UpdateAnimatorGroundBool(_groundChecker.IsConcatWithLayer);
    }

    public void TryJump()
    {
        if (_groundChecker.IsConcatWithLayer)
        {
            Rigidbody.linearVelocityY = _jumpForce;
        }
    }
}
