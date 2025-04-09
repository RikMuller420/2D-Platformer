using UnityEngine;

public class PatrolBehaviour : MoveBehaviour
{
    private MoveAviablilityChecker _moveAviablilityChecker;
    private float _maxPatrolDistance = 5f;
    private Vector2 _startPatrolPoint;
    private float _moveDirection = 1;

    public PatrolBehaviour(CreatureMover mover, MoveAviablilityChecker moveAviablilityChecker,
                            float maxPatrolDistance, float patrolSpeed) :
                            base(mover, patrolSpeed)
    {
        _startPatrolPoint = mover.Creature.position;
        _moveAviablilityChecker = moveAviablilityChecker;
        _maxPatrolDistance = maxPatrolDistance;
    }

    public override void Move()
    {
        if (IsDirectionSwapRequired(Mover.Creature))
        {
            SwapMoveDirection();
        }

        float velocityX = _moveDirection * Speed;
        Mover.MoveHorizontal(velocityX);
    }

    private bool IsDirectionSwapRequired(Transform creature)
    {
        if (IsOutOfPatrolRange(creature))
        {
            return IsFacingToStartPatrolPoint(creature) == false;
        }

        return _moveAviablilityChecker.IsAbleToMoveForward == false;
    }

    private void SwapMoveDirection()
    {
        _moveDirection = (_moveDirection > 0) ? -1 : 1;
    }

    private bool IsOutOfPatrolRange(Transform creature)
    {
        float sqrMaxPatrolDistance = _maxPatrolDistance * _maxPatrolDistance;

        return ((Vector2)creature.position - _startPatrolPoint).sqrMagnitude > sqrMaxPatrolDistance;
    }

    private bool IsFacingToStartPatrolPoint(Transform creature)
    {
        if (creature.position.x > _startPatrolPoint.x)
        {
            return _moveDirection < 0;
        }
        else
        {
            return _moveDirection > 0;
        }
    }
}
