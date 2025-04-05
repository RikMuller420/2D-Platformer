using UnityEngine;

public class PlayerAnimator : CreatureAnimator
{
    private readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    [SerializeField] private PlayerGroundChecker _playerGroundChecker;

    private void OnEnable()
    {
        _playerGroundChecker.GroundedStateChanged += UpdateAnimatorGroundBool;
    }
    private void OnDisable()
    {
        _playerGroundChecker.GroundedStateChanged -= UpdateAnimatorGroundBool;
    }

    private void UpdateAnimatorGroundBool()
    {
        Animator.SetBool(IsGrounded, _playerGroundChecker.IsGrounded);
    }
}
