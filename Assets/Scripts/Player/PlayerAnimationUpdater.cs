using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationUpdater : MonoBehaviour
{
    private const string BlendSpeedValueName = "MoveSpeed";

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerGroundChecker _playerGroundChecker;

    [SerializeField] private float moveSpeedAnimationCorrection = 0.2f;


    private void OnEnable()
    {
        _playerGroundChecker.GroundedStateChanged += UpdateAnimGroundBool;
    }
    private void OnDisable()
    {
        _playerGroundChecker.GroundedStateChanged -= UpdateAnimGroundBool;
    }

    private void Update()
    {
        float animatorSpeed = Mathf.Abs(_rigidbody.linearVelocityX) * moveSpeedAnimationCorrection;
        animator.SetFloat(BlendSpeedValueName, animatorSpeed);


    }

    private void UpdateAnimGroundBool()
    {
        animator.SetBool("IsGrounded", _playerGroundChecker.IsGrounded);
    }
}
