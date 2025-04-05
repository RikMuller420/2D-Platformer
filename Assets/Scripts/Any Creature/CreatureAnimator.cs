using UnityEngine;

public class CreatureAnimator : MonoBehaviour
{
    private readonly int MoveSpeed = Animator.StringToHash(nameof(MoveSpeed));
    private readonly int Death = Animator.StringToHash(nameof(Death));

    [SerializeField] protected Animator Animator;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeedAnimationCorrection = 0.7f;

    public void UpdateMoveAnimation()
    {
        float animatorSpeed = Mathf.Abs(_rigidbody.linearVelocityX) * _moveSpeedAnimationCorrection;
        Animator.SetFloat(MoveSpeed, animatorSpeed);
    }

    public void PlayDeadAnimation()
    {
        Animator.SetTrigger(Death);
        enabled = false;
    }
}
