using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private readonly int Attack = Animator.StringToHash(nameof(Attack));

    [SerializeField] private LayerMask _attackLayer;
    [SerializeField] private Collider2D _damageArea;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackDistance = 1.5f;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _attackDelay = 0.25f;
    [SerializeField] private float _reloadDuration = 1f;

    private DetectorOfDamagableTarget _targetDetector;
    private bool _isReloading = false;
    private WaitForSeconds _waitAttackDelay;
    private WaitForSeconds _waitCooldown;

    public event Action OnAttackStarted;

    private void Awake()
    {
        _targetDetector = new DetectorOfDamagableTarget(transform, _attackLayer,
                                                    _attackDistance, _damageArea);
        _waitAttackDelay = new WaitForSeconds(_attackDelay);
        _waitCooldown = new WaitForSeconds(_reloadDuration);
    }

    public void TryAttack(Transform target)
    {
        if (_isReloading)
        {
            return;
        }

        if (_targetDetector.IsTargetInRange(target))
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        _isReloading = true;
        _animator.SetTrigger(Attack);
        OnAttackStarted?.Invoke();
        StartCoroutine(DealDamageInDelay());
    }

    private IEnumerator DealDamageInDelay()
    {
        yield return _waitAttackDelay;

        DealDamage();

        yield return Reload();
    }

    private void DealDamage()
    {
        List<IDamagable> targets = _targetDetector.GetDamagablesInAttackArea();

        foreach (IDamagable target in targets)
        {
            target.TakeDamage(_damage);
        }
    }

    private IEnumerator Reload()
    {
        yield return _waitCooldown;

        _isReloading = false;
    }
}
