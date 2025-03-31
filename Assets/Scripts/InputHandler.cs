using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpKeyCode = KeyCode.Space;

    public event Action<float> horizontalMoveInput;
    public event Action jumpInput;


    private void Update()
    {
        float moveInput = Input.GetAxis(HorizontalAxisName);
        horizontalMoveInput?.Invoke(moveInput);

        if (Input.GetKeyDown(JumpKeyCode))
        {
            jumpInput?.Invoke();
        }
    }
}
