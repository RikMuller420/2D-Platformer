using System.Collections.Generic;
using UnityEngine;

public class SpellZoneDetector : MonoBehaviour
{
    private Health _spellOwner;
    private List<Health> _enemies = new List<Health>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health damagable))
        {
            if (damagable == _spellOwner)
            {
                return;
            }

            _enemies.Add(damagable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health damagable))
        {
            if (damagable == _spellOwner)
            {
                return;
            }

            _enemies.Remove(damagable);
        }
    }

    public void Initialize(Health spellOwner)
    {
        _spellOwner = spellOwner;
    }

    public bool TryGetClosestTarget(out Health closestTarget)
    {
        closestTarget = null;

        if (_enemies.Count == 0)
        {
            return false;
        }

        float minSqrDist = float.MaxValue;

        foreach (Health damagable in _enemies)
        {
            float sqrDist = (damagable.transform.position - transform.position).sqrMagnitude;

            if (sqrDist < minSqrDist)
            {
                minSqrDist = sqrDist;
                closestTarget = damagable;
            }
        }

        return true;
    }
}
