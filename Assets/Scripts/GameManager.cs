using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject xrOrigin;
    public static GameManager instance; // Singleton reference
    public FadeScreen fadeScreen;

    // Player states
    public SO_Gun[] Guns { get; private set; }

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

    private void Start()
    {
        xrOrigin = GameObject.Find("XR Origin");
        fadeScreen = GameObject.Find("XR Origin/Camera Offset/Main Camera/FadeScreen").GetComponent<FadeScreen>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        xrOrigin = GameObject.Find("XR Origin");
        fadeScreen = xrOrigin.transform.Find("Camera Offset/Main Camera/FadeScreen").GetComponent<FadeScreen>();

        if (xrOrigin)
        {
            ChangeGun changeGunScript = xrOrigin.GetComponent<ChangeGun>();
            if (changeGunScript)
            {
                changeGunScript.guns = Guns;
            }
        }
    }


    private void OnDestroy()
    {
        // Unsubscribe from the event when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Scene transition with fade effect
    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        if (xrOrigin)
        {
            ChangeGun changeGunScript = xrOrigin.GetComponent<ChangeGun>();
            if (changeGunScript)
            {
                Guns = changeGunScript.guns;
            }
        }
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }

}
