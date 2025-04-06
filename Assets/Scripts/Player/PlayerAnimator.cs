using UnityEngine;

public class PlayerAnimator : CreatureAnimator
{
    private readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    public void UpdateAnimatorGroundBool(bool isGrounded)
    {
        Animator.SetBool(IsGrounded, isGrounded);
    }
}
