using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class vvod : MonoBehaviour, Controls.IGirlwithknifeActions
{
    private Controls Klavishi;
    private Vector2 movement;
    public Vector2 Movement => movement;
    private void OnEnable()
    {
        Klavishi = new Controls();
        Klavishi.girlwithknife.SetCallbacks(this);
        Klavishi.girlwithknife.Enable();
    } 
    private void OnDisable()
    {
        Klavishi.girlwithknife.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("you jump");
    }

    public void OnKortochki(InputAction.CallbackContext context)
    {
        Debug.Log("you Kortochki");
    }

    public void OnMoment(InputAction.CallbackContext context)
    {
        Debug.Log("you move");
        movement = context.ReadValue<Vector2>();
    }

    public void OnPolzat(InputAction.CallbackContext context)
    {
        Debug.Log("you Polzat");
    }
}
