using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Gun_Base : MonoBehaviour
{
    [SerializeField] private string gunType;
    private XROrigin xrOrigin;
    public GameObject gunPrefab { get; private set; }

    protected void Start()
    {
        xrOrigin = FindObjectOfType<XROrigin>();
        gunPrefab = this.gameObject;
    }

    public void TriggerRegister()
    {
        ChangeGun changeGun = xrOrigin.GetComponent<ChangeGun>();
        changeGun.RegisterGun(this);
    }

    public string GetGunType()
    {
        return gunType;
    }
}
