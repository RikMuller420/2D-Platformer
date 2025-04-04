using UnityEngine;

public class CreatureOrientationChanger : MonoBehaviour
{
    [SerializeField] private CreatureMover _creature;

    private bool _isFacingRight = true;
    private float _facingRightAngle = 0f;
    private float _facingLeftAngle = 180;

    private Quaternion _facingLeftRotation;
    private Quaternion _facingRightRotation;

    private void Awake()
    {
        _facingLeftRotation = Quaternion.Euler(0f, _facingLeftAngle, 0f);
        _facingRightRotation = Quaternion.Euler(0f, _facingRightAngle, 0f);
    }

    private void FixedUpdate()
    {
        if (_creature.MoveDirection == Direction.Right && _isFacingRight == false)
        {
            Flip();
        }
        else if (_creature.MoveDirection == Direction.Left && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.rotation = _isFacingRight ? _facingRightRotation : _facingLeftRotation;
    }
}
