using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(ResourceCollector))]
public class Player : HealthCreature
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private ResourceCollector _resourceCollector;

    private bool _isJumpPressed;

    private void OnEnable()
    {
        _resourceCollector.HealthBoosterCollected += Heal;
        _inputHandler.JumpPressed += RegisterJumpPressed;
    }

    private void OnDisable()
    {
        _resourceCollector.HealthBoosterCollected -= Heal;
        _inputHandler.JumpPressed -= RegisterJumpPressed;
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputHandler.HorizontalMove);

        if (_isJumpPressed)
        {
            _mover.TryJump();
        }

        _attacker.TryAttack();
        _isJumpPressed = false;
    }

    private void RegisterJumpPressed()
    {
        _isJumpPressed = true;
    }
}
