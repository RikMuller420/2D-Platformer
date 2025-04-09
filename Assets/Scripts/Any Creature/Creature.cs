using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField] protected CreatureAnimator Animator;

    [SerializeField] private Collider2D _collider;

    protected void OnEnable()
    {
        Health.HealthExpired += Death;
    }

    protected void OnDisable()
    {
        Health.HealthExpired -= Death;
    }

    private void Death()
    {
        enabled = false;
        _collider.enabled = false;
        Rigidbody.simulated = false;
        Animator.PlayDeadAnimation();
    }
}
