using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CreatureOrientationChanger))]
public abstract class CreatureMover : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField] protected CreatureAnimator Animator;

    [SerializeField] private CreatureOrientationChanger _orientationChanger;

    public void MoveHorizontal(float velocityX)
    {
        Rigidbody.linearVelocityX = velocityX;
        Animator.UpdateMoveAnimation(velocityX);
        _orientationChanger.UpdateOrientation(velocityX);
    }
}
