using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected Slider Bar;

    protected void Start()
    {
        UpdateIndicator();
    }

    private void OnEnable()
    {
        Health.Changed += UpdateIndicator;
    }

    private void OnDisable()
    {
        Health.Changed -= UpdateIndicator;
    }

    protected virtual void UpdateIndicator()
    {
        Bar.value = Health.Value / Health.MaxValue;
    }
}
