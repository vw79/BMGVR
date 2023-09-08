using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Gun_Base : MonoBehaviour
{
    [SerializeField] private SO_Gun gun;


    public void TriggerRegister()
    {
        ChangeGun changeGun = GameObject.Find("XR Origin").GetComponent<ChangeGun>();
        changeGun.RegisterGun(this);
    }

    public void SpawnGun(Transform player)
    {
        if(gun.gunPrefab != null)
        {
            Instantiate(gun.gunPrefab, GetPlayerFrontPosition(player), player.rotation);
        }
    }

    public SO_Gun GetGun()
    {
        return gun;
    }

    public string GetGunType()
    {
        return gun.gunType;
    }

    private Vector3 GetPlayerFrontPosition(Transform player)
    {
        return player.position + (player.gameObject.GetNamedChild("Main Camera").transform.forward * 3) + new Vector3(0,1,0);
    }
}
