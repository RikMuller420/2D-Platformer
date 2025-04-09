using UnityEngine;

public class PlayerMover : CreatureMover
{
    private PlayerAnimator _playerAnimator;
    private LayerContactChecker _groundChecker;
    private float _moveSpeed = 5f;
    private float _jumpForce = 12f;

    public PlayerMover(Rigidbody2D rigidbody, PlayerAnimator animator,
                        CreatureOrientationChanger orientationChanger,
                        LayerContactChecker groundChecker, float moveSpeed, float jumpForce) :
                        base(rigidbody, animator, orientationChanger)
    {
        _groundChecker = groundChecker;
        _moveSpeed = moveSpeed;
        _jumpForce = jumpForce;
        _playerAnimator = animator;
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
