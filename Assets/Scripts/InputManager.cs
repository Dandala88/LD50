using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private PlayerInput playerInput;

    public void Move(CallbackContext context)
    {
        if(context.performed)
        {
            player.Move(context.ReadValue<Vector2>());
        }
    }

    public void Jump(CallbackContext context)
    {
        if (context.started)
        {
            player.Jump();
        }

        if (context.canceled)
        {
            player.JumpCanceled();
        }
    }

}
