using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpKeyCode = KeyCode.Space;

    private bool _isJump;

    public float HorizontalMove { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxis(HorizontalAxisName);

        if (Input.GetKeyDown(JumpKeyCode))
        {
            _isJump = true;
        }
    }

    public bool GetIsJumpTrigger()
    {
        bool bufferIsJump = _isJump;
        _isJump = false;

        return bufferIsJump;
    }
}
