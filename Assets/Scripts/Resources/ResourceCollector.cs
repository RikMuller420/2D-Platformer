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
            resource.Collect(this);
        }
    }

    public void Collect(Coin coin)
    {
        CoinCollected?.Invoke();
    }

    public void Collect(HealthBooster healthBooster)
    {
        HealthBoosterCollected?.Invoke(healthBooster.HealthRestoreAmount);
    }
}
