using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class DefaultCollectableResource : MonoBehaviour, ICollectableResource
{
    private const string AnimatorDeactivateTriggerName = "Disappear";

    [SerializeField] protected Collider2D Collider;

    [SerializeField] private Animator _animator;

    public void Collect()
    {
        Deactivate();
    }
    public void Activate()
    {
        Collider.enabled = true;
        gameObject.SetActive(true);
    }

    protected virtual void Deactivate()
    {
        Collider.enabled = false;
        _animator.SetTrigger(AnimatorDeactivateTriggerName);
    }
}
