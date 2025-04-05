using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(HealthBoosterCollector))]
public class Player : MortalCreature
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private HealthBoosterCollector _healthBoosterCollector;

    private void OnEnable()
    {
        _healthBoosterCollector.OnHealthBoosterCollected += Heal;
    }

    private void OnDisable()
    {
        _healthBoosterCollector.OnHealthBoosterCollected -= Heal;
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputHandler.HorizontalMove);

        if (_inputHandler.GetIsJumpTrigger())
        {
            _mover.TryJump();
        }

        _attacker.TryAttack();
        Animator.UpdateMoveAnimation();
    }
}
