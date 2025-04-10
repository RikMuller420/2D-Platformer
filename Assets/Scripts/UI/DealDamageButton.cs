using UnityEngine;
using UnityEngine.UI;

public class DealDamageButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _health;
    [SerializeField] private float _damage = 10f;

    private void OnEnable()
    {
        _button.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DealDamage);
    }

    private void DealDamage()
    {
        _health.TakeDamage(_damage);
    }
}
