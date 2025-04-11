using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField] protected CreatureAnimator Animator;

    protected CreatureOrientationChanger OrientationChanger;

    [SerializeField] private Transform _facingRoot;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private HealthBar _healthBar;

    protected void Awake()
    {
        OrientationChanger = new CreatureOrientationChanger(_facingRoot);
    }

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
        _healthBar.DeactivateHealthBar();
    }
}
