using UnityEngine;

public class CreatureMover
{
    protected Rigidbody2D Rigidbody;

    private CreatureAnimator _animator;
    private CreatureOrientationChanger _orientationChanger;

    public CreatureMover(Rigidbody2D rigidbody, CreatureAnimator animator,
                         CreatureOrientationChanger orientationChanger)
    {
        Rigidbody = rigidbody;
        Creature = rigidbody.transform;
        _animator = animator;
        _orientationChanger = orientationChanger;
    }

    public Transform Creature { get; }

    public void MoveHorizontal(float velocityX)
    {
        Rigidbody.linearVelocityX = velocityX;
        _animator.UpdateMoveAnimation(velocityX);
        _orientationChanger.UpdateOrientation(velocityX);
    }
}
