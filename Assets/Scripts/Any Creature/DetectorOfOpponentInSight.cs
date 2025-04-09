using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DetectorOfOpponentInSight : MonoBehaviour
{
    [SerializeField] private LayerMask _opponentLayer;
    [SerializeField] private float _detectDistance = 7f;

    private int _opponentContacts = 0;
    private bool _isOpponentInCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _opponentLayer) != 0)
        {
            _opponentContacts++;
            _isOpponentInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _opponentLayer) != 0)
        {
            _opponentContacts--;

            if (_opponentContacts <= 0)
            {
                _opponentContacts = 0;
                _isOpponentInCollider = false;
            }
        }
    }

    public bool IsOpponentInSight(out Transform opponent)
    {
        opponent = null;

        if (_isOpponentInCollider == false)
        {
            return false;
        }

        Debug.DrawLine(transform.position, transform.position + transform.right * _detectDistance);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right,
                                            _detectDistance, _opponentLayer);

        if (hit.collider != null)
        {
            opponent = hit.transform;

            return true;
        }

        return false;
    }
}
