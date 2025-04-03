using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimatorFieldsSynchronizer : AnimatorMoveFieldSynchronizer
{
    private readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    [SerializeField] private PlayerGroundChecker _playerGroundChecker;

    private void OnEnable()
    {
        _playerGroundChecker.GroundedStateChanged += UpdateAnimGroundBool;
    }
    private void OnDisable()
    {
        _playerGroundChecker.GroundedStateChanged -= UpdateAnimGroundBool;
    }

    private void UpdateAnimGroundBool()
    {
        _animator.SetBool(IsGrounded, _playerGroundChecker.IsGrounded);
    }
}
