using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PatrolBehaviour))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PatrolBehaviour _patrolBehaviour;
    [SerializeField] private float _patrolSpeed = 1.2f;

    private void FixedUpdate()
    {
        Direction moveDirection = _patrolBehaviour.GetDirection();

        float velocityX = (int)moveDirection * _patrolSpeed;
        _rigidbody.linearVelocityX = velocityX;
    }
}
