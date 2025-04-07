using System;
using System.Collections;
using UnityEngine;

public class Coin : DefaultCollectableResource
{
    [SerializeField] private float _disableDelay = 2f;

    private WaitForSeconds _wait;

    public event Action<Coin> Deactivated;

    private void Awake()
    {
        _wait = new WaitForSeconds(_disableDelay);
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        StartCoroutine(DeactivateInDelay());
    }

    private IEnumerator DeactivateInDelay()
    {
        yield return _wait;

        gameObject.SetActive(false);
        Deactivated?.Invoke(this);
    }
}
