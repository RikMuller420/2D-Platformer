using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerGroundChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerGroundChecker _groundChecker;

    private void FixedUpdate()
    {
        _mover.Move(_inputHandler.HorizontalMove);

        if (_inputHandler.IsJumpTrigger && _groundChecker.IsGrounded)
        {
            _mover.Jump();
        }
    }
}
