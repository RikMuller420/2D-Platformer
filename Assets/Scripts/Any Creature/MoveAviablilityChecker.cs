using UnityEngine;

public class MoveAviablilityChecker : MonoBehaviour
{
    [SerializeField] private float _checkBottomDistance = 0.5f;
    [SerializeField] private float _checkSideDistance = 0.6f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsAbleToMoveForward(Direction moveDirection)
    {
        if (IsGoundForward(moveDirection) && IsWallForward(moveDirection) == false)
        {
            return true;
        }

        return false;
    }

    private bool IsGoundForward(Direction moveDirection)
    {
        Vector2 offset = Vector2.right * (int)moveDirection * _checkSideDistance;
        Vector2 rayOrigin = (Vector2)transform.position + offset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, _checkBottomDistance, _groundLayer);

        return hit.collider != null;
    }

    private bool IsWallForward(Direction moveDirection)
    {
        Vector2 rayDirection = Vector2.right * (int)moveDirection;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, rayDirection,
                                            _checkSideDistance, _groundLayer);

        return hit.collider != null;
    }
}
