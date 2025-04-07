using UnityEngine;

public class PatrolBehaviour : IMoveBehaviour
{
    private MoveAviablilityChecker _moveAviablilityChecker;
    private float _maxPatrolDistance = 5f;
    private Vector2 _startPatrolPoint;
    private float _moveDirection = 1;
    private float _patrolSpeed = 1.2f;

    public PatrolBehaviour(Transform startPoint, MoveAviablilityChecker moveAviablilityChecker,
                            float maxPatrolDistance, float patrolSpeed)
    {
        _startPatrolPoint = startPoint.position;
        _moveAviablilityChecker = moveAviablilityChecker;
        _maxPatrolDistance = maxPatrolDistance;
        _patrolSpeed = patrolSpeed;
    }

    public void Move(CreatureMover creature)
    {
        if (IsDirectionSwapRequired(creature.transform))
        {
            SwapMoveDirection();
        }

        float velocityX = _moveDirection * _patrolSpeed;
        creature.MoveHorizontal(velocityX);
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
