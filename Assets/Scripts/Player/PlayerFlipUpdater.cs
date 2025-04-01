using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFlipUpdater : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private Transform _transformToFlip;

    private bool _isFacingRight = true;

    private void Update()
    {
        float moveDirection = Mathf.Sign(_playerRigidbody.linearVelocityX);

        if (_playerRigidbody.linearVelocityX > 0 && _isFacingRight == false)
        {
            Flip();
        }
        else if (_playerRigidbody.linearVelocityX < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = _transformToFlip.localScale;
        scale.x *= -1;
        _transformToFlip.localScale = scale;
    }
}
