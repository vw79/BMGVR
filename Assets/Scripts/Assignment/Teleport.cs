using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : MonoBehaviour
{
    [Header("Teleportation Button")]
    [SerializeField] public InputAction teleportAction;

    [Header("Line Renderer")]
    public LineRenderer lineRenderer; // Drag and drop your LineRenderer component here in the inspector
    private bool isLineRendererActive = false; // To check the state of the LineRenderer

    void Start()
    {
        // Add listener for the action
        teleportAction.performed += HandleButtonPress;

        // Enable the action
        teleportAction.Enable();

        // Initially disable the LineRenderer
        lineRenderer.enabled = false;
    }

    void Update()
    {

    }

    private void HandleButtonPress(InputAction.CallbackContext context)
    {
        if (isLineRendererActive)
        {
            MoveToLineEndPosition();
            lineRenderer.enabled = false;
            isLineRendererActive = false;
        }
        else
        {
            EnableLineRenderer();
            isLineRendererActive = true;
        }
    }

    private void EnableLineRenderer()
    {
        Vector3 start = transform.position;
        Vector3 end = GetPlayerFrontPosition();

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;
    }

    private void MoveToLineEndPosition()
    {
        Vector3 endPosition = lineRenderer.GetPosition(1);
        GameObject xrRig = GameObject.Find("XR Origin"); // Assuming the XR Rig is named 'XR Rig'
        if (xrRig != null)
        {
            xrRig.transform.position = new Vector3(endPosition.x, xrRig.transform.position.y, endPosition.z);
        }
    }

    private Vector3 GetPlayerFrontPosition()
    {
        return transform.position + (GameObject.Find("Main Camera").transform.forward * 3) + new Vector3(0, 1, 0);
    }
}