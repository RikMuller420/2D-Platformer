using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpKeyCode = KeyCode.Space;

    public event Action<float> HorizontalMoveInputAction;
    public event Action JumpInputAction;

    private void Update()
    {
        float moveInput = Input.GetAxis(HorizontalAxisName);
        HorizontalMoveInputAction?.Invoke(moveInput);

        if (Input.GetKeyDown(JumpKeyCode))
        {
            JumpInputAction?.Invoke();
        }
    }
}
