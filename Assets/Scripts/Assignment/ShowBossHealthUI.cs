using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowBossHealthUI : MonoBehaviour
{
    [Header("Insert Left Hand A Button")]
    [SerializeField] public InputAction aButtonAction;

    [SerializeField] private GameObject bossHealthUI;

    // Start is called before the first frame update
    void Start()
    {
        aButtonAction.performed += ShowBossHealth;

        aButtonAction.Enable();
    }

    
    private void ShowBossHealth(InputAction.CallbackContext context)
    {
        if (bossHealthUI.active == true) return;
        StartCoroutine(ShowBossHealthTimer());
    }

    IEnumerator ShowBossHealthTimer()
    {
        bossHealthUI.SetActive(true);
        yield return new WaitForSeconds(7f);
        bossHealthUI.SetActive(false);
    }
}
