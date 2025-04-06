using System.Collections;
using UnityEngine;

public class HealthBooster : DefaultCollectableResource
{
    [SerializeField] private float _healthRestoreAmount = 50f;
    [SerializeField] private float _destroyDelay = 2f;

    public float HealthRestoreAmount => _healthRestoreAmount;

    public override void Collect(ResourceCollector collector)
    {
        collector.Collect(this);
        Deactivate();
    }

    override protected void Deactivate()
    {
        base.Deactivate();
        StartCoroutine(DestroyInDelay(_destroyDelay));
    }

    private IEnumerator DestroyInDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
