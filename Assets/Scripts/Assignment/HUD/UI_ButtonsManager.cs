using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// (please put this script in canva component)
// Script for UI canvas to track buttons and do their functions.

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
            if (button.name == "Button Start")      //(change the button name)
            {
                button.onClick.AddListener(() => buttonsFunction.StartGame());      //(apply the function)
            }

            //(repeat here)
        }
    }
}
