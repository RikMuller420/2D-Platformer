using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterOrientationChanger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private Transform _transformToFlip;

    private bool _isFacingRight = true;
    private float _facingRightAngle = 0f;
    private float _facingLeftAngle = 180;

    private void LateUpdate()
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
        float rotateAngle = _isFacingRight ? _facingRightAngle : _facingLeftAngle;
        _transformToFlip.rotation = Quaternion.Euler(0f, rotateAngle, 0f);
    }
}
