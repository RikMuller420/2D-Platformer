using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimatorUpdater : AnimatorMoveFieldUpdater
{
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
        animator.SetBool("IsGrounded", _playerGroundChecker.IsGrounded);
    }
}
