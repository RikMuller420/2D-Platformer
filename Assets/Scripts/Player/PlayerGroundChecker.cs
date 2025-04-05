using System;
using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public event Action GroundedStateChanged;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(transform.position, _checkRadius, _groundLayer);

        if (isGrounded != IsGrounded)
        {
            IsGrounded = isGrounded;
            GroundedStateChanged?.Invoke();
        }
    }
}
