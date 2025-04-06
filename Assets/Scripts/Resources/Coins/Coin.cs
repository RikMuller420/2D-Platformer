using System;
using System.Collections;
using UnityEngine;

public class Coin : DefaultCollectableResource
{
    [SerializeField] private float _disableDelay = 2f;

    public event Action Deactivated;

    public override void Collect(ResourceCollector collector)
    {
        collector.Collect(this);
        Deactivate();
    }

    override protected void Deactivate()
    {
        base.Deactivate();
        StartCoroutine(DeactivateInDelay(_disableDelay));
    }

    private IEnumerator DeactivateInDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.SetActive(false);
        Deactivated?.Invoke();
    }
}
