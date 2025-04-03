using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpKeyCode = KeyCode.Space;

    private bool _isJump;

    public float HorizontalMove { get; private set; }
    public bool IsJumpTrigger { get => GetIsJump(); }

    private void Update()
    {
        HorizontalMove = Input.GetAxis(HorizontalAxisName);

        if (Input.GetKeyDown(JumpKeyCode))
        {
            _isJump = true;
        }
    }

    private bool GetIsJump()
    {
        bool bufferIsJump = _isJump;
        _isJump = false;

        return bufferIsJump;
    }
}
