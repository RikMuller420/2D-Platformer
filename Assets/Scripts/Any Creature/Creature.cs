using System.Collections;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField] protected CreatureAnimator Animator;

    protected CreatureOrientationChanger OrientationChanger;

    [SerializeField] private Transform _facingRoot;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private CanvasGroup _healthBar;

    private float _deactivateHealthBarDuration = 1f;

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
        StartCoroutine(DeactivatingHealthBar());
    }

    private IEnumerator DeactivatingHealthBar()
    {
        float time = 0f;
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (time < _deactivateHealthBarDuration)
        {
            time += Time.deltaTime;
            _healthBar.alpha = Mathf.Lerp(1f, 0f, time / _deactivateHealthBarDuration);

            yield return wait;
        }
    }
}
