using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private readonly int Attack = Animator.StringToHash(nameof(Attack));

    [SerializeField] private DetectorOfDamagableTarget _targetDetector;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _attackDelay = 0.25f;
    [SerializeField] private float _reloadDuration = 1f;

    private bool isReloading = false;

    public event Action OnAttackStarted;

    public void TryAttack()
    {
        if (isReloading)
        {
            return;
        }

        if (_targetDetector.IsDamagableInRange())
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        isReloading = true;
        _animator.SetTrigger(Attack);
        OnAttackStarted?.Invoke();
        StartCoroutine(DealDamageInDelay());
    }

    private IEnumerator DealDamageInDelay()
    {
        yield return new WaitForSeconds(_attackDelay);

        DealDamage();

        yield return SetReadyToAttackInDelay();
    }

    private void DealDamage()
    {
        List<IDamagable> targets = _targetDetector.GetDamagablesInAttackArea();

        foreach (IDamagable target in targets)
        {
            target.TakeDamage(_damage);
        }
    }

    private IEnumerator SetReadyToAttackInDelay()
    {
        yield return new WaitForSeconds(_reloadDuration);

        isReloading = false;
    }
}
