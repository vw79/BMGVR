using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (please put this script in canva component)
// Script for UI canvas to follow camera (player) view.

public class UI_Follow : MonoBehaviour
{
    // for camera
    [SerializeField] private Transform playerCam_Transform;

    // for UI
    [SerializeField] private float distanceFromCamera = 1.0f;

    private void LateUpdate()
    {
        if (playerCam_Transform != null)
        {
            transform.position = playerCam_Transform.position + (playerCam_Transform.forward) * distanceFromCamera;
            transform.rotation = Quaternion.LookRotation(transform.position - playerCam_Transform.position); //(Need to think its logic)
        }
    }
}
