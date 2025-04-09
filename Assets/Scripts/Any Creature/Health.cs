using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth = 100f;

    public event Action HealthExpired;

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
        _health = Math.Clamp(_health, 0, _maxHealth);

        if (_health == 0)
        {
            HealthExpired?.Invoke();
        }
    }

    public void Heal(float health)
    {
        if (health < 0)
        {
            health = 0;
        }

        _health += health;
        _health = Math.Clamp(_health, 0, _maxHealth);
    }
}