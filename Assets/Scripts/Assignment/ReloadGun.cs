using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReloadGun : MonoBehaviour
{
    [Header("Insert Right Hand B Button")]
    [SerializeField] public InputAction bButtonAction;

    // Start is called before the first frame update
    void Start()
    {
        bButtonAction.performed += Reload;

        bButtonAction.Enable();
    }

    // Update is called once per frame
    private void Reload(InputAction.CallbackContext context)
    {
        GameObject[] existedGuns = GameObject.FindGameObjectsWithTag("Gun");
        foreach (GameObject gun in existedGuns)
        {
            if(gun.GetComponent<Gun_Base>() != null)
            {
                gun.GetComponent<Gun_Base>().StartReloading();
            }
        }
    }
}
