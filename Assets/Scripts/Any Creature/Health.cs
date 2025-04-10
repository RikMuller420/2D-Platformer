using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxValue = 100f;

    public event Action Changed;
    public event Action HealthExpired;

    public float Value { get; private set; }
    public float MaxValue => _maxValue;

    private void Awake()
    {
        Value = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }

        Value -= damage;
        Value = Math.Clamp(Value, 0, _maxValue);

        Changed?.Invoke();

        if (Value == 0)
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

        Value += health;
        Value = Math.Clamp(Value, 0, _maxValue);

        Changed?.Invoke();
    }
}