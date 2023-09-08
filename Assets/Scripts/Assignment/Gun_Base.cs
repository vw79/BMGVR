using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Base : MonoBehaviour
{
    [SerializeField] private string gunType;

    public string GetGunType()
    {
        return gunType;
    }
}
