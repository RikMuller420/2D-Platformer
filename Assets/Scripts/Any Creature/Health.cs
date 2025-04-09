using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxValue = 100f;

    public event Action HealthExpired;

    private float _value;

    private void Awake()
    {
        _value = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }


        _value -= damage;
        _value = Math.Clamp(_value, 0, _maxValue);

        if (_value == 0)
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

        _value += health;
        _value = Math.Clamp(_value, 0, _maxValue);
    }
}