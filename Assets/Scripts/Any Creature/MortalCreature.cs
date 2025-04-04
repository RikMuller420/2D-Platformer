using UnityEngine;

public abstract class MortalCreature : MonoBehaviour, IDamagable
{
    [SerializeField] protected CreatureAnimator Animator;

    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _maxHealth = 100f;

    private float _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }

        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Death();
        }
    }

    public void Heal(float health)
    {
        _health += health;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void Death()
    {
        enabled = false;
        _collider.enabled = false;
        _rigidbody.simulated = false;
        Animator.PlayDeadAnimation();
    }
}