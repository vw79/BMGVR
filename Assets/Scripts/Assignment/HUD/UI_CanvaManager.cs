using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class UI_CanvaManager : MonoBehaviour
{
    [SerializeField] bool hideCanvasAtStart;
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();

        
    }

    void Update()
    {
        
    }
}
