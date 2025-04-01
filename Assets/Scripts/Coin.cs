using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private const string AnimatorDeactivateTriggerName = "Disappear";

    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _disableDelay = 2f;

    public void Activate()
    {
        _collider.enabled = true;
    }

    public void Deactivate()
    {
        _collider.enabled = false;
        _animator.SetTrigger(AnimatorDeactivateTriggerName);
        StartCoroutine(DeactivateInDelay(_disableDelay));
    }

    private IEnumerator DeactivateInDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.SetActive(false);
    }
}
