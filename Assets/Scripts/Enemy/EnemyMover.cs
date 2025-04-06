using UnityEngine;

public class EnemyMover : CreatureMover
{
    [SerializeField] private MoveAviablilityChecker groundChecker;
    [SerializeField] private DetectorOfPlayerInSight _detectorOfPlayerInSight;
    [SerializeField, Min(3f)] private float _maxPatrolDistance = 5f;
    [SerializeField, Min(0.5f)] private float _patrolSpeed = 1.2f;
    [SerializeField, Min(0.5f)] private float _chaseSpeed = 2f;

    private PatrolBehaviour _patrolBehaviour;
    private ChaseBehaviour _chaseBehaviour;
    private IMoveBehaviour _moveBehaviour;

    public float MoveSpeed { get; private set; }

    private void Awake()
    {
        _patrolBehaviour = new PatrolBehaviour(transform, groundChecker, _maxPatrolDistance);
        _chaseBehaviour = new ChaseBehaviour(groundChecker);
    }

    public void Move()
    {
        UpdateMoveBehaviour();
        Direction moveDirection = _moveBehaviour.GetMoveDirection(transform);

        float velocityX = (int)moveDirection * MoveSpeed;
        MoveHorizontal(velocityX);
    }

    private void UpdateMoveBehaviour()
    {
        if (_detectorOfPlayerInSight.IsPlayerInSight(out Transform player))
        {
            _moveBehaviour = _chaseBehaviour;
            _chaseBehaviour.SetTargetToChase(player);
            MoveSpeed = _chaseSpeed;
        }
        else
        {
            _moveBehaviour = _patrolBehaviour;
            MoveSpeed = _patrolSpeed;
        }
    }
}
