using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpKeyCode = KeyCode.Space;

    public event Action JumpPressed;

    public float HorizontalMove { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxis(HorizontalAxisName);

        if (Input.GetKeyDown(JumpKeyCode))
        {
            JumpPressed?.Invoke();
        }
    }
}
