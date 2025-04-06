using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class DefaultCollectableResource : MonoBehaviour, ICollectableResource
{
    private const string AnimatorDeactivateTriggerName = "Disappear";

    [SerializeField] protected Collider2D Collider;

    [SerializeField] private Animator _animator;

    public abstract void Collect(ResourceCollector collector);

    public void Activate()
    {
        Collider.enabled = true;
        gameObject.SetActive(true);
    }

    virtual protected void Deactivate()
    {
        Collider.enabled = false;
        _animator.SetTrigger(AnimatorDeactivateTriggerName);
    }
}
