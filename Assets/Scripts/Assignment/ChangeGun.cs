using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeGun : MonoBehaviour
{
    public SO_Gun[] guns;
    private int currentGunIndex = 0;

    [Header("Insert Right Hand A Button")]
    [SerializeField] public InputAction aButtonAction;

    // Start is called before the first frame update
    void Start()
    {
        // Add listener for the action
        aButtonAction.performed += SpawnGun;

        // Enable the action
        aButtonAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterGun(Gun_Base gun)
    {
        if(!GunRegistered(gun))
        {
            guns = guns.Append(gun.GetGun()).ToArray();
        }
    }

    private bool GunRegistered(Gun_Base gun)
    {
        foreach(SO_Gun saved_gun in guns)
        {
            if(saved_gun.gunType == gun.GetGunType())
            {
                return true;
            }
        }
        return false;
    }

    private void SpawnGun(InputAction.CallbackContext context)
    {
        GameObject[] existedGuns = GameObject.FindGameObjectsWithTag("Gun");
        foreach (GameObject gun in existedGuns)
        {
            if(gun.GetComponent<Gun_Base>() != null)
            {
                if(GunRegistered(gun.GetComponent<Gun_Base>()))
                {
                    Destroy(gun);
                }
            }
        }

        currentGunIndex = (currentGunIndex + 1) % guns.Length;
        for (int i = 0; i < guns[currentGunIndex].gunCount; i++)
        {
            Instantiate(guns[currentGunIndex].gunPrefab, new Vector3(GetPlayerFrontPosition().x, Mathf.Clamp(GetPlayerFrontPosition().y, 1.5f, Mathf.Infinity), GetPlayerFrontPosition().z), transform.rotation);
        }
    }

    private Vector3 GetPlayerFrontPosition()
    {
        return transform.position + (GameObject.Find("Main Camera").transform.forward * 3) + new Vector3(0,1,0);
    }
}
