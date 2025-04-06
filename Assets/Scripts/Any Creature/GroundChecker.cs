using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public event Action GroundedStateChanged;
    private Collider2D[] _checkResults = new Collider2D[1];

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, _checkRadius,
                                                        _checkResults, _groundLayer);
        bool isGrounded = hitCount > 0;

        if (isGrounded != IsGrounded)
        {
            IsGrounded = isGrounded;
            GroundedStateChanged?.Invoke();
        }
    }
}
