using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Player : Creature
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private ResourceCollector _resourceCollector;
    [SerializeField] private DetectorOfOpponentInSight _enemyDetector;
    [SerializeField] private LayerContactChecker _groundChecker;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 12f;

    private PlayerMover _mover;
    private bool _isJumpPressed;

    private new void Awake()
    {
        base.Awake();
        PlayerAnimator animator = Animator as PlayerAnimator;
        _mover = new PlayerMover(Rigidbody, animator, OrientationChanger,
                                _groundChecker, _moveSpeed, _jumpForce);
    }

    private new void OnEnable()
    {
        base.OnEnable();
        _resourceCollector.HealthBoosterCollected += Health.Heal;
        _inputHandler.JumpPressed += RegisterJumpPressed;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        _resourceCollector.HealthBoosterCollected -= Health.Heal;
        _inputHandler.JumpPressed -= RegisterJumpPressed;
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputHandler.HorizontalMove);

        if (_isJumpPressed)
        {
            _mover.TryJump();
            _isJumpPressed = false;
        }

        if (_enemyDetector.IsOpponentInSight(out Transform enemy))
        {
            _attacker.TryAttack(enemy);
        }
    }

    private void RegisterJumpPressed()
    {
        _isJumpPressed = true;
    }
}
