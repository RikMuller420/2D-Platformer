using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyGroundChecker))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1.2f;
    [SerializeField] private float _maxPatrolDistance = 5f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private EnemyGroundChecker _groundChecker;

    private Direction _moveDirection = Direction.Right;
    private Vector2 _startPatrolPoint;

    private void Awake()
    {
        _startPatrolPoint = transform.position;
    }

    private void Update()
    {
        if (IsDirectionSwapRequired())
        {
            SwapMoveDirection();
        }

        float velocityX = (int)_moveDirection * _speed;
        _rigidbody.linearVelocityX = velocityX;
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

        bool canMoveForward = _groundChecker.IsAbleToMoveForward(_moveDirection);

        if (canMoveForward == false)
        {
            return true;
        }

        return false;
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
        return ((Vector2)transform.position - _startPatrolPoint).magnitude > _maxPatrolDistance;
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
