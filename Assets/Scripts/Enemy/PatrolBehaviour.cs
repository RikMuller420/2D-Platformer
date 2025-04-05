using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyGroundChecker _groundChecker;
    [SerializeField] private float _maxPatrolDistance = 5f;

    private Vector2 _startPatrolPoint;
    private Direction _moveDirection = Direction.Right;

    private void Awake()
    {
        _startPatrolPoint = transform.position;
    }

    public Direction GetDirection()
    {
        if (IsDirectionSwapRequired())
        {
            SwapMoveDirection();
        }

        return _moveDirection;
    }

    private bool IsDirectionSwapRequired()
    {
        if (IsOutOfPatrolRange())
        {
            if (IsFacingToStartPatrolPoint() == false)
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

    private bool IsOutOfPatrolRange()
    {
        float sqrMaxPatrolDistance = _maxPatrolDistance * _maxPatrolDistance;

        return ((Vector2)transform.position - _startPatrolPoint).sqrMagnitude > sqrMaxPatrolDistance;
    }

    private bool IsFacingToStartPatrolPoint()
    {
        if (transform.position.x > _startPatrolPoint.x)
        {
            return _moveDirection == Direction.Left;
        }
        else
        {
            return _moveDirection == Direction.Right;
        }
    }
}
