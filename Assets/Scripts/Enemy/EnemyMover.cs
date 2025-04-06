using UnityEngine;

public class EnemyMover : CreatureMover
{
    [SerializeField] private MoveAviablilityChecker _moveAviablilityChecker;
    [SerializeField] private DetectorOfPlayerInSight _detectorOfPlayerInSight;
    [SerializeField, Min(3f)] private float _maxPatrolDistance = 5f;
    [SerializeField, Min(0.5f)] private float _patrolSpeed = 1.2f;
    [SerializeField, Min(0.5f)] private float _chaseSpeed = 2f;

    private PatrolBehaviour _patrolBehaviour;
    private ChaseBehaviour _chaseBehaviour;
    private IMoveBehaviour _moveBehaviour;
    private float _moveSpeed;

    private void Awake()
    {
        _patrolBehaviour = new PatrolBehaviour(transform, _moveAviablilityChecker, _maxPatrolDistance);
        _chaseBehaviour = new ChaseBehaviour(_moveAviablilityChecker);
    }

    public void Move()
    {
        UpdateMoveBehaviour();

        float moveDirection = _moveBehaviour.GetMoveDirection(transform);
        float velocityX = moveDirection * _moveSpeed;
        MoveHorizontal(velocityX);
    }

    private void UpdateMoveBehaviour()
    {
        if (_detectorOfPlayerInSight.IsPlayerInSight(out Transform player))
        {
            _moveBehaviour = _chaseBehaviour;
            _chaseBehaviour.SetTargetToChase(player);
            _moveSpeed = _chaseSpeed;
        }
        else
        {
            _moveBehaviour = _patrolBehaviour;
            _moveSpeed = _patrolSpeed;
        }
    }
}
