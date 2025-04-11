using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected Slider Bar;

    [SerializeField] private CanvasGroup _canvasGroup;

    private float _deactivateHealthBarDuration = 1f;

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

    public void DeactivateHealthBar()
    {
        StartCoroutine(DeactivatingHealthBar());
    }

    protected virtual void UpdateIndicator()
    {
        Bar.value = Health.Value / Health.MaxValue;
    }

    private IEnumerator DeactivatingHealthBar()
    {
        float time = 0f;
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (time < _deactivateHealthBarDuration)
        {
            time += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(1f, 0f, time / _deactivateHealthBarDuration);

            yield return wait;
        }
    }
}
