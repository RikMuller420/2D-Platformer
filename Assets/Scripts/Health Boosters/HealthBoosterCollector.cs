using System;
using UnityEngine;

public class HealthBoosterCollector : MonoBehaviour
{
    public event Action<float> OnHealthBoosterCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthBooster healthBooster))
        {
            GetHealthBooster(healthBooster);
        }
    }

    private void GetHealthBooster(HealthBooster healthBooster)
    {
        OnHealthBoosterCollected?.Invoke(healthBooster.HealthRestoreAmount);
        healthBooster.Deactivate();
    }
}
