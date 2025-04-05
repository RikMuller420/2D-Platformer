using System.Collections.Generic;
using UnityEngine;

public class DetectorOfDamagableTarget : MonoBehaviour
{
    [SerializeField] private LayerMask _detectLayer;
    [SerializeField] private float _detectDistance = 1.5f;
    [SerializeField] private Collider2D _damageArea;

    public bool IsDamagableInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,
                                            _detectDistance, _detectLayer);

        if (hit.collider != null && hit.collider.TryGetComponent<IDamagable>(out _))
        {
            return true;
        }

        return false;
    }

    public List<IDamagable> GetDamagablesInAttackArea()
    {
        Collider2D[] hits = Physics2D.OverlapAreaAll(
            _damageArea.bounds.min,
            _damageArea.bounds.max,
            _detectLayer
        );

        List<IDamagable> damagables = new List<IDamagable>();

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out IDamagable damagable))
            {
                damagables.Add(damagable);
            }
        }

        return damagables;
    }
}
