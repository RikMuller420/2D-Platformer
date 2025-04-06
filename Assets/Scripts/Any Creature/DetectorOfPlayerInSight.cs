using UnityEngine;

public class DetectorOfPlayerInSight : MonoBehaviour
{
    [SerializeField] private LayerMask _detectLayer;
    [SerializeField] private float _detectDistance = 7f;

    public bool IsPlayerInSight(out Transform player)
    {
        player = null;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,
                                            _detectDistance, _detectLayer);

        if (hit.collider != null && hit.collider.TryGetComponent<Player>(out _))
        {
            player = hit.transform;

            return true;
        }

        return false;
    }
}
