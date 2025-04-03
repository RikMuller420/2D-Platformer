using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpKeyCode = KeyCode.Space;
    private bool _isJump;

    public float MoveInput { get; private set; }
    public bool IsJump { get => GetIsJump(); }

    private void Update()
    {
        MoveInput = Input.GetAxis(HorizontalAxisName);

        if (Input.GetKeyDown(JumpKeyCode))
        {
            _isJump = true;
        }
    }

    public bool GetIsJump()
    {
        bool bufferIsJump = _isJump;
        _isJump = false;

        return bufferIsJump;
    }
}
