using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpKeyCode = KeyCode.Space;
    private const KeyCode CastSpellKeyCode = KeyCode.Q;

    public event Action JumpPressed;
    public event Action CastSpellPressed;

    public float HorizontalMove { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxis(HorizontalAxisName);

        if (Input.GetKeyDown(JumpKeyCode))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetKeyDown(CastSpellKeyCode))
        {
            CastSpellPressed?.Invoke();
        }
    }
}
