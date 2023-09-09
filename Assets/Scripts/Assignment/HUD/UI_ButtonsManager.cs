using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// (please put this script in canva component)
// Script for UI canvas to track buttons and do their functions.

[RequireComponent(typeof(ButtonsFunction))]

public class UI_ButtonsManager : MonoBehaviour
{
    public ButtonsFunction buttonsFunction;

    public List<Button> buttons;

    void Start()
    {
        Button[] buttonsArray = GetComponentsInChildren<Button>();
        buttons.AddRange(buttonsArray);

        buttonsFunction = GetComponent<ButtonsFunction>();

        foreach (Button button in buttons)
        {
            switch (button.name)
            {
                case "Play":
                    button.onClick.AddListener(() => buttonsFunction.StartGame());
                    break;

                case "Quit":
                    button.onClick.AddListener(() => buttonsFunction.QuitGame());
                    break;

                case "Back":
                    button.onClick.AddListener(() => buttonsFunction.ReturnScene());
                    break;
            }
        }
    }
}
