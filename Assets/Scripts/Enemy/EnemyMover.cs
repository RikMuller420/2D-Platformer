using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PatrolBehaviour))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PatrolBehaviour _patrolBehaviour;

    private void FixedUpdate()
    {
        Direction moveDirection = _patrolBehaviour.GetDirection();

        float velocityX = (int)moveDirection * _patrolBehaviour.Speed;
        _rigidbody.linearVelocityX = velocityX;
    }
}
