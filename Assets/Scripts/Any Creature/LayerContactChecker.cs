using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LayerContactChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    private int _groundContacts = 0;

    public event Action GroundedStateChanged;

    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _groundLayer) != 0)
        {
            _groundContacts++;
            SetNewGroundState(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _groundLayer) != 0)
        {
            _groundContacts--;

            if (_groundContacts <= 0)
            {
                _groundContacts = 0;
                SetNewGroundState(false);
            }
        }
    }

    private void SetNewGroundState(bool isGrounded)
    {
        bool isGroundedBuffer = IsGrounded;
        IsGrounded = isGrounded;

        if (IsGrounded != isGroundedBuffer)
        {
            GroundedStateChanged?.Invoke();
        }
    }
}
