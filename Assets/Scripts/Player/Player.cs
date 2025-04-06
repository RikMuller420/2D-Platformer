using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(ResourceCollector))]
public class Player : MortalCreature
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private ResourceCollector _resourceCollector;

    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        SetMaxHealth();
        _playerAnimator = (PlayerAnimator)Animator;
    }

    private void OnEnable()
    {
        _resourceCollector.HealthBoosterCollected += Heal;
    }

    private void OnDisable()
    {
        _resourceCollector.HealthBoosterCollected -= Heal;
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputHandler.HorizontalMove);

        if (_inputHandler.GetIsJumpTrigger())
        {
            _mover.TryJump();
        }

        _attacker.TryAttack();

        _playerAnimator.UpdateMoveAnimation(_inputHandler.HorizontalMove);
        _playerAnimator.UpdateAnimatorGroundBool(_mover.IsGrounded);
    }
}
