using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeGun : MonoBehaviour
{
    public Gun_Base[] guns;

    [Header("A button")]
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
        if(guns.Contains(gun) == false)
        {
            guns = guns.Append(gun).ToArray();
        }
    }

    private void SpawnGun(InputAction.CallbackContext context)
    {
        guns[0].SpawnGun();
    }
}
