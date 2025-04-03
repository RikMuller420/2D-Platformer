using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerGroundChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerMover mover;
    [SerializeField] private PlayerGroundChecker _groundChecker;

    private void FixedUpdate()
    {
        mover.Move(_inputHandler.MoveInput);

        if (_inputHandler.IsJump && _groundChecker.IsGrounded)
        {
            mover.Jump();
        }
    }
}
