using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _checkPosition;
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(_checkPosition.position, _checkRadius, _groundLayer);
    }
}
