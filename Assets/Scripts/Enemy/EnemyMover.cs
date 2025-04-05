using UnityEngine;

[RequireComponent(typeof(PatrolBehaviour))]
[RequireComponent(typeof(ChaseBehaviour))]
public class EnemyMover : CreatureMover
{
    [SerializeField] private PatrolBehaviour _patrolBehaviour;
    [SerializeField] private ChaseBehaviour _chaseBehaviour;
    [SerializeField] private DetectorOfPlayerInSight _detectorOfPlayerInSight;

    [SerializeField, Min(0.5f)] private float _patrolSpeed = 1.2f;
    [SerializeField, Min(0.5f)] private float _chaseSpeed = 2f;

    private EnemyMoveBehaviour _moveBehaviour = EnemyMoveBehaviour.Patrol;

    public void Move()
    {
        UpdateMoveBehaviour();
        Direction moveDirection = GetMoveDirection();
        float moveSpeed = GetMoveSpeed();

        float velocityX = (int)moveDirection * moveSpeed;
        MoveHorizontal(velocityX);
    }

    private void UpdateMoveBehaviour()
    {
        if (_detectorOfPlayerInSight.IsPlayerInSight(out Transform player))
        {
            _moveBehaviour = EnemyMoveBehaviour.ChaseTarget;
            _chaseBehaviour.SetTargetToChase(player);
        }
        else
        {
            _moveBehaviour = EnemyMoveBehaviour.Patrol;
        }
    }

    private Direction GetMoveDirection()
    {
        switch (_moveBehaviour)
        {
            case EnemyMoveBehaviour.Patrol:
                return _patrolBehaviour.GetDirection();

            case EnemyMoveBehaviour.ChaseTarget:
                return _chaseBehaviour.GetDirection();

            default:
                return Direction.Right;
        }
    }

    private float GetMoveSpeed()
    {
        switch (_moveBehaviour)
        {
            case EnemyMoveBehaviour.Patrol:
                return _patrolSpeed;

            case EnemyMoveBehaviour.ChaseTarget:
                return _chaseSpeed;

            default:
                return 0f;
        }
    }
}
