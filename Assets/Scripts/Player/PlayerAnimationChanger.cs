using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationChanger : MonoBehaviour
{
    private const string BlendSpeedValueName = "MoveSpeed";

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float moveSpeedAnimationCorrection = 0.2f;

    private void Update()
    {
        float animatorSpeed = Mathf.Abs(_rigidbody.linearVelocityX) * moveSpeedAnimationCorrection;
        animator.SetFloat(BlendSpeedValueName, animatorSpeed);
    }
}
