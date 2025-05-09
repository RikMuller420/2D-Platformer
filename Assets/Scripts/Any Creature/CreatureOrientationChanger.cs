using UnityEngine;

public class CreatureOrientationChanger
{
    private Transform _facingRoot;
    private bool _isFacingRight = true;
    private float _facingRightAngle = 0f;
    private float _facingLeftAngle = 180;

    private Quaternion _facingLeftRotation;
    private Quaternion _facingRightRotation;

    public CreatureOrientationChanger(Transform facingRoot)
    {
        _facingRoot = facingRoot;
        _facingLeftRotation = Quaternion.Euler(0f, _facingLeftAngle, 0f);
        _facingRightRotation = Quaternion.Euler(0f, _facingRightAngle, 0f);
    }

    public void UpdateOrientation(float moveDirection)
    {
        if (moveDirection > 0 && _isFacingRight == false)
        {
            Flip();
        }
        else if (moveDirection < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _facingRoot.rotation = _isFacingRight ? _facingRightRotation : _facingLeftRotation;
    }
}
