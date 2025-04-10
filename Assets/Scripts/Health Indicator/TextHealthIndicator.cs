using TMPro;
using UnityEngine;

public class TextHealthIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        UpdateIndicator();
    }

    private void OnEnable()
    {
        _health.Changed += UpdateIndicator;
    }

    private void OnDisable()
    {
        _health.Changed -= UpdateIndicator;
    }

    private void UpdateIndicator()
    {
        _text.text = $"{_health.Value}/{_health.MaxValue}";
    }
}
