using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_IgnoreCollision : MonoBehaviour
{
    private void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("XR Origin").GetComponent<Collider>());
    }
}
