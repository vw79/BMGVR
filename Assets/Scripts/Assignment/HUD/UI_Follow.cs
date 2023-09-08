using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (please put this script in canva component)
// Script for UI canvas to follow camera (player) view.

public class UI_Follow : MonoBehaviour
{
    // for camera
    [SerializeField] private Transform FollowTarget;

    // for UI
    [SerializeField] private float distanceFromCamera = 1.0f;

    private void LateUpdate()
    {
        if (FollowTarget != null)
        {
            transform.position = FollowTarget.position + (FollowTarget.forward) * distanceFromCamera;
            transform.rotation = Quaternion.LookRotation(transform.position - FollowTarget.position); //(Need to think its logic)
        }
    }
}
