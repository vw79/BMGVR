using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton reference
    public FadeScreen fadeScreen;

    // Player states
    public bool shotgunGet { get; private set; }
    public bool smgGet { get; private set; }
    public bool shotgunTrap { get; private set; }
    public bool smgTrap { get; private set; }

    private void Awake()
    {
        // Implement Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update the player states
    public void SetShotgunGet(bool value)
    {
        shotgunGet = value;
        Debug.Log("Shotgun get: " + shotgunGet);
    }

    public void SetSMGGet(bool value)
    {
        smgGet = value;
        Debug.Log("SMG get: " + smgGet);
    }

    public void SetShotgunTrap(bool value)
    {
        shotgunTrap = value;
    }

    public void SetSMGTrap(bool value)
    {
        smgTrap = value;
    }

    // Scene transition with fade effect
    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
