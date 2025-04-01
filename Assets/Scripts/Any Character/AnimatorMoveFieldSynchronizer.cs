using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AnimatorMoveFieldSynchronizer : MonoBehaviour
{
    private const string BlendSpeedValueName = "MoveSpeed";

    [SerializeField] protected Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeedAnimationCorrection = 0.7f;

    private void Update()
    {
        float animatorSpeed = Mathf.Abs(_rigidbody.linearVelocityX) * _moveSpeedAnimationCorrection;
        _animator.SetFloat(BlendSpeedValueName, animatorSpeed);
    }
}
