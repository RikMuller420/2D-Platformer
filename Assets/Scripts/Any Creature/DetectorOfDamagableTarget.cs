using System.Collections.Generic;
using UnityEngine;

public class DetectorOfDamagableTarget
{
    private const int MaxHitTargets = 8;

    private Transform _creature;
    private LayerMask _detectLayer;
    private float _detectDistance = 1.5f;
    private Collider2D _damageArea;

    private Collider2D[] _hitBuffer = new Collider2D[MaxHitTargets];

    public DetectorOfDamagableTarget(Transform creature, LayerMask detectLayer,
                                        float detectDistance, Collider2D damageArea)
    {
        _creature = creature;
        _detectLayer = detectLayer;
        _detectDistance = detectDistance;
        _damageArea = damageArea;
    }

    public bool IsTargetInRange(Transform target)
    {
        float distanceToTarget = Mathf.Abs(target.position.x - _creature.position.x);

        return distanceToTarget <= _detectDistance;
    }

    public List<IDamagable> GetDamagablesInAttackArea()
    {
        int hitCount = Physics2D.OverlapAreaNonAlloc(
            _damageArea.bounds.min,
            _damageArea.bounds.max,
            _hitBuffer,
            _detectLayer
        );

        List<IDamagable> damagables = new List<IDamagable>();

        for (int i = 0; i < hitCount; i++)
        {
            if (_hitBuffer[i].TryGetComponent(out IDamagable damagable))
            {
                damagables.Add(damagable);
            }
        }

        return damagables;
    }
}
