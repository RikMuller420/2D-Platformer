using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpellZoneDetector))]
public class VampirismSpell : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Health _spellOwner;
    [SerializeField] private SpellZoneDetector _zoneDetector;
    [SerializeField] private float _castDuration = 6f;
    [SerializeField] private float _reloadDuration = 4f;
    [SerializeField] private float _damagePerSecond = 10f;

    private WaitForEndOfFrame _wait = new WaitForEndOfFrame();

    public event Action StateChanged;

    public SpellState State { get; private set; } = SpellState.Ready;
    public float CastTime { get; private set; }
    public float ReloadTime { get; private set; }
    public float CastDuration => _castDuration;
    public float ReloadDuration => _reloadDuration;

    private void Awake()
    {
        _zoneDetector.Initialize(_spellOwner);
    }

    private void OnEnable()
    {
        _inputHandler.CastSpellPressed += TryActive;
    }

    private void OnDisable()
    {
        _inputHandler.CastSpellPressed -= TryActive;
    }

    private void TryActive()
    {
        if (State == SpellState.Ready)
        {
            Activate();
        }
    }

    private void Activate()
    {
        SetNewState(SpellState.Casting);
        _zoneDetector.enabled = true;
        StartCoroutine(Casting());
    }

    private IEnumerator Casting()
    {
        CastTime = 0f;

        while (CastTime < _castDuration)
        {
            CastTime += Time.deltaTime;
            PerformVampirismTick();

            yield return _wait;
        }

        _zoneDetector.enabled = false;
        SetNewState(SpellState.Realoding);

        yield return Reloading();
    }

    private IEnumerator Reloading()
    {
        ReloadTime = 0f;

        while (ReloadTime < _reloadDuration)
        {
            ReloadTime += Time.deltaTime;

            yield return _wait;
        }

        SetNewState(SpellState.Ready);
    }

    private void PerformVampirismTick()
    {
        if (_zoneDetector.TryGetClosestTarget(out IDamagable target) == false)
        {
            return;
        }

        float hitPoints = Time.deltaTime * _damagePerSecond;
        target.TakeDamage(hitPoints);
        _spellOwner.Heal(hitPoints);
    }

    private void SetNewState(SpellState state)
    {
        State = state;
        StateChanged?.Invoke();
    }
}
