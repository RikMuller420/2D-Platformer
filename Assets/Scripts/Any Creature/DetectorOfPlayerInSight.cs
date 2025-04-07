using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DetectorOfPlayerInSight : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _detectDistance = 7f;

    private int _playerContacts = 0;
    private bool _isPlayerInCollider;

    public bool IsPlayerInSight(out Transform player)
    {
        player = null;

        if (_isPlayerInCollider == false)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right,
                                            _detectDistance, _layer);

        if (hit.collider != null && hit.collider.TryGetComponent<Player>(out _))
        {
            player = hit.transform;

            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _layer) != 0)
        {
            _playerContacts++;
            _isPlayerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _layer) != 0)
        {
            _playerContacts--;

            if (_playerContacts <= 0)
            {
                _playerContacts = 0;
                _isPlayerInCollider  = false;
            }
        }
    }
}
