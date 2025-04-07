using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Attacker))]
public class Enemy : HealthCreature
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Attacker _attacker;

    private void FixedUpdate()
    {
        _mover.Move();
        _attacker.TryAttack();
    }
}
