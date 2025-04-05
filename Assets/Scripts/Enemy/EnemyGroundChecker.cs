using UnityEngine;

public class EnemyGroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkBottomDistance = 0.5f;
    [SerializeField] private float _checkSideDistance = 0.6f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsAbleToMoveForward(Direction moveDirection)
    {
        Vector2 offset = Vector2.right * (int)moveDirection * _checkSideDistance;
        Vector2 rayOrigin = (Vector2)transform.position + offset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, _checkBottomDistance, _groundLayer);

        return hit.collider != null;
    }
}
