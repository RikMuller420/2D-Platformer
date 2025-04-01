using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AnimatorMoveFieldUpdater : MonoBehaviour
{
    private const string BlendSpeedValueName = "MoveSpeed";

    [SerializeField] protected Animator animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeedAnimationCorrection = 0.7f;

    private void Update()
    {
        float animatorSpeed = Mathf.Abs(_rigidbody.linearVelocityX) * _moveSpeedAnimationCorrection;
        animator.SetFloat(BlendSpeedValueName, animatorSpeed);
    }
}
