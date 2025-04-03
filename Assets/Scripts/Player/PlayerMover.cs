using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 12f;

    public void Move(float moveInput)
    {
        _rigidbody.linearVelocityX = moveInput * _moveSpeed;
    }

    public void Jump()
    {
        _rigidbody.linearVelocityY = _jumpForce;
    }
}
