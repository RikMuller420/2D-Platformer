using System;
using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    public event Action GroundedStateChanged;

    [SerializeField] private Transform _checkPosition;
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(_checkPosition.position, _checkRadius, _groundLayer);

        if (isGrounded != IsGrounded)
        {
            IsGrounded = isGrounded;
            GroundedStateChanged?.Invoke();
        }
    }
}
