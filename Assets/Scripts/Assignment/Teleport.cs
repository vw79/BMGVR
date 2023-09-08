using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : MonoBehaviour
{
    [Header("Ray Interaction")]
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider teleportationProvider;

    [Header("A button")]
    [SerializeField] private InputAction aButtonAction;
    [SerializeField] private InputAction bButtonAction;

    [Header("Line Renderer for Teleportation")]
    [SerializeField] private LineRenderer teleportLine;
    private Vector3 teleportDestination;

    void Start()
    {
        rayInteractor.enabled = false;
        teleportLine.enabled = false;

        // Add listener for the aButtonAction and enable it
        aButtonAction.performed += OnAButtonPressed;
        aButtonAction.Enable();
    }

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        if (teleportLine.enabled)
        {
            // If the line renderer is enabled, teleport the player to the destination
            TeleportPlayer();
        }
        else
        {
            // If the line renderer is not enabled, show the teleport line
            ShowTeleportLine();
        }
    }

    private void ShowTeleportLine()
    {
        teleportLine.enabled = true;

        // Define the start and end points of the line renderer
        teleportLine.SetPosition(0, transform.position);

        // Assuming the end point is 5 units in front of the player
        teleportDestination = transform.position + transform.forward * 5f;
        teleportLine.SetPosition(1, teleportDestination);
    }

    private void TeleportPlayer()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit))
        {
            TeleportRequest teleportRequest = new TeleportRequest()
            {
                destinationPosition = raycastHit.point,
            };

            teleportationProvider.QueueTeleportRequest(teleportRequest);
            teleportLine.enabled = false;
        }
    }
}
