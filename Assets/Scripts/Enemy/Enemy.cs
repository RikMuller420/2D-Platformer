using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Enemy : Creature
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private MoveAviablilityChecker _moveAviablilityChecker;
    [SerializeField] private DetectorOfOpponentInSight _playerDetector;

    [SerializeField, Min(3f)] private float _maxPatrolDistance = 5f;
    [SerializeField, Min(0.5f)] private float _patrolSpeed = 1.2f;
    [SerializeField, Min(0.5f)] private float _chaseSpeed = 2f;

    private CreatureMover _mover;
    private MoveBehaviour _moveBehaviour;
    private PatrolBehaviour _patrolBehaviour;
    private ChaseBehaviour _chaseBehaviour;

    private Transform _player;
    private bool _isPlayerInSight = false;

    private void Awake()
    {
        CreatureOrientationChanger orientationChanger = new CreatureOrientationChanger(transform);
        _mover = new CreatureMover(Rigidbody, Animator, orientationChanger);
        _patrolBehaviour = new PatrolBehaviour(_mover, _moveAviablilityChecker, _maxPatrolDistance, _patrolSpeed);
        _chaseBehaviour = new ChaseBehaviour(_mover, _moveAviablilityChecker, _chaseSpeed);
    }

    private void FixedUpdate()
    {
        _isPlayerInSight = _playerDetector.IsOpponentInSight(out _player);
        UpdateMoveBehaviour();
        _moveBehaviour.Move();

        if (_isPlayerInSight)
        {
            _attacker.TryAttack(_player);
        }
    }

    private void UpdateMoveBehaviour()
    {
        if (_isPlayerInSight)
        {
            _moveBehaviour = _chaseBehaviour;
            _chaseBehaviour.SetTargetToChase(_player);
        }
        else
        {
            _moveBehaviour = _patrolBehaviour;
        }
    }
}
