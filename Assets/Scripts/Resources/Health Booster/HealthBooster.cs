using System.Collections;
using UnityEngine;

public class HealthBooster : DefaultCollectableResource
{
    [SerializeField] private float _healthRestoreAmount = 50f;
    [SerializeField] private float _destroyDelay = 2f;

    private WaitForSeconds _wait;

    public float HealthRestoreAmount => _healthRestoreAmount;

    private void Awake()
    {
        _wait = new WaitForSeconds(_destroyDelay);
    }

    public override void Collect(ResourceCollector collector)
    {
        collector.Collect(this);
        Deactivate();
    }

    override protected void Deactivate()
    {
        base.Deactivate();
        StartCoroutine(DestroyInDelay());
    }

    private IEnumerator DestroyInDelay()
    {
        yield return _wait;

        Destroy(gameObject);
    }
}
