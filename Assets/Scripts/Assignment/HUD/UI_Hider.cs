using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

// (please put this script in canva component)
// Script for UI canvas to follow camera (player) view.

public class UI_Hider : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] Button buttonTrigger;
    private bool clicked = false;

    [SerializeField] bool hideCanvas;
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        HideCanvasExecuter();
    }

    private void HideCanvasExecuter()
    {
        if(Boss != null) //if boss is existed
        {
            canvas.enabled = false; //hide ui
        }

        if(buttonTrigger != null)
        {
            buttonTrigger.onClick.AddListener(ClickBoolChanger);
            canvas.enabled = !clicked;
        }

        else
        {
            canvas.enabled = !hideCanvas;
        }
    }

    private void ClickBoolChanger()
    {
        clicked = true;
    }
}
