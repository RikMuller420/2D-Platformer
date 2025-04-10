using System.Collections;
using UnityEngine;

public class SmoothHealthBar : HealthBar
{
    [SerializeField, Min(0.05f)] private float changeDuration = 0.3f;

    private float _startValue;
    private float _targetValue;
    private float _time;
    private Coroutine _changeBarCoroutine;
    private WaitForEndOfFrame _wait = new WaitForEndOfFrame();

    private new void Start()
    {
        base.UpdateIndicator();
    }

    protected override void UpdateIndicator()
    {
        if (_changeBarCoroutine != null)
        {
            StopCoroutine(_changeBarCoroutine);
        }

        _changeBarCoroutine = StartCoroutine(ChangingBarValue());
    }

    private IEnumerator ChangingBarValue()
    {
        _time = 0f;
        _startValue = Bar.value;
        _targetValue = Health.Value / Health.MaxValue;

        while (_time < changeDuration)
        {
            _time += Time.deltaTime;
            Bar.value = Mathf.Lerp(_startValue, _targetValue, _time / changeDuration);
            yield return _wait;
        }
    }
}
