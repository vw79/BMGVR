using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_IgnoreBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(12, 11);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
