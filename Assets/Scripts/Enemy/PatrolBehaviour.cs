using UnityEngine;

public class PatrolBehaviour : IMoveBehaviour
{
    private MoveAviablilityChecker _groundChecker;
    private float _maxPatrolDistance = 5f;
    private Vector2 _startPatrolPoint;
    private Direction _moveDirection = Direction.Right;

    public PatrolBehaviour(Transform startPoint, MoveAviablilityChecker groundChecker, float maxPatrolDistance)
    {
        _startPatrolPoint = startPoint.position;
        _groundChecker = groundChecker;
        _maxPatrolDistance = maxPatrolDistance;
    }

    public Direction GetMoveDirection(Transform creature)
    {
        if (IsDirectionSwapRequired(creature))
        {
            SwapMoveDirection();
        }

        return _moveDirection;
    }

    private bool IsDirectionSwapRequired(Transform creature)
    {
        if (IsOutOfPatrolRange(creature))
        {
            if (IsFacingToStartPatrolPoint(creature) == false)
            {
                return true;
            }
        }

        return _groundChecker.IsAbleToMoveForward(_moveDirection) == false;
    }

    private void SwapMoveDirection()
    {
        if (_moveDirection == Direction.Right)
        {
            _moveDirection = Direction.Left;
        }
        else
        {
            _moveDirection = Direction.Right;
        }
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
            return _moveDirection == Direction.Left;
        }
        else
        {
            return _moveDirection == Direction.Right;
        }
    }
}
