using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ResourceCollector : MonoBehaviour
{
    public event Action CoinCollected;
    public event Action<float> HealthBoosterCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectableResource resource))
        {
            Collect(resource);
        }
    }

    private void Collect(ICollectableResource resource)
    {
        resource.Collect();

        switch (resource)
        {
            case Coin:
                CoinCollected?.Invoke();
                break;

            case HealthBooster:
                Collect(resource as HealthBooster);
                break;
        }
    }

    private void Collect(HealthBooster healthBooster)
    {
        HealthBoosterCollected?.Invoke(healthBooster.HealthRestoreAmount);
    }
}
