using UnityEngine;

public class ChaseBehaviour : MoveBehaviour
{
    private MoveAviablilityChecker _moveAviablilityChecker;
    private Transform _target;

    public ChaseBehaviour(CreatureMover mover, MoveAviablilityChecker moveAviablilityChecker,
                            float chaseSpeed) : base(mover, chaseSpeed)
    {
        _moveAviablilityChecker = moveAviablilityChecker;
    }

    public override void Move()
    {
        float moveDirection = Mathf.Sign(_target.position.x - Mover.Creature.position.x);

        if (_moveAviablilityChecker.IsAbleToMoveForward == false)
        {
            moveDirection = 0;
        }

        float velocityX = moveDirection * Speed;
        Mover.MoveHorizontal(velocityX);
    }

    public void SetTargetToChase(Transform target)
    {
        _target = target;
    }
}
