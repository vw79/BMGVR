using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            // Check the tag of the trap door
            if (this.CompareTag("SMGTrap"))
            {
                GameManager.instance.SetSMGTrap(true);
            }
            else if (this.CompareTag("ShotgunTrap"))
            {
                GameManager.instance.SetShotgunTrap(true);
            }

            Destroy(gameObject);
        }
    }
}