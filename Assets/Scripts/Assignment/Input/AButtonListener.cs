using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AButtonListener : MonoBehaviour
{
    // Reference to the InputAction
    [SerializeField] public InputAction aButtonAction;

    private void OnEnable()
    {
        // Add listener for the action
        aButtonAction.performed += OnAButtonPressed;

        // Enable the action
        aButtonAction.Enable();
    }

    private void OnDisable()
    {
        // Remove the listener when the object is disabled
        aButtonAction.performed -= OnAButtonPressed;

        // Disable the action
        aButtonAction.Disable();
    }

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        // Log message when A button is pressed
        Debug.Log("A button was pressed!");
    }
}
