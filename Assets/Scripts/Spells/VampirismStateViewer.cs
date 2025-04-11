using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismStateViewer : MonoBehaviour
{
    [SerializeField] private VampirismSpell _spell;
    [SerializeField] private SpriteRenderer _zoneView;
    [SerializeField] private Image _durationImage;

    private WaitForEndOfFrame _wait = new WaitForEndOfFrame();

    private void OnEnable()
    {
        _spell.StateChanged += StatedChanged;
    }

    private void OnDisable()
    {
        _spell.StateChanged -= StatedChanged;
    }

    private void StatedChanged()
    {
        switch (_spell.State)
        {
            case SpellState.Casting:
                StartCoroutine(TrackCasting());
                break;

            case SpellState.Realoding:
                StartCoroutine(TrackReloading());
                break;
        }
    }

    private IEnumerator TrackCasting()
    {
        _zoneView.enabled = true;

        while (_spell.State == SpellState.Casting)
        {
            float fillAmount = 1f - _spell.CastTime / _spell.CastDuration;
            _durationImage.fillAmount = fillAmount;

            yield return _wait;
        }

        _zoneView.enabled = false;
    }

    private IEnumerator TrackReloading()
    {
        while (_spell.State == SpellState.Realoding)
        {
            float fillAmount = _spell.ReloadTime / _spell.ReloadDuration;
            _durationImage.fillAmount = fillAmount;

            yield return _wait;
        }
    }
}
