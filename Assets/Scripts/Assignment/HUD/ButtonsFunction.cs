using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonsFunction : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas winMenuCanvas;
    public GameObject tutorialCanvas;
    public ActionBasedContinuousMoveProvider moveProvider;
    public AudioSource bgmSource;
    public AudioClip bgmClip;
    public AudioClip winClip;

    void Start()
    {
        if (mainMenuCanvas != null)
        {
            moveProvider.moveSpeed = 0;
        }

        if (tutorialCanvas)
        {
            tutorialCanvas.gameObject.SetActive(false);
        }

        if (winMenuCanvas)
        {
            winMenuCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Starting the game");

        // Disable main menu
        if (mainMenuCanvas)
        {
            mainMenuCanvas.gameObject.SetActive(false);
        }

        // Enable tutorial canvas
        if (tutorialCanvas)
        {
            tutorialCanvas.gameObject.SetActive(true);
        }

        // Set move speed to 5
        if (moveProvider != null)
        {
            moveProvider.moveSpeed = 5;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
        // Uncomment the next line if you want to stop the game in the editor
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void RestartGame()
    {
        if (moveProvider != null)
        {
            moveProvider.moveSpeed = 0;
        }

        Time.timeScale = 1;

        // Assuming the first scene in your build settings is the starting scene of your game
        SceneManager.LoadScene(0);
    }

    public void ToggleWin()
    {
        bgmSource.clip = winClip;
        bgmSource.loop = false;
        bgmSource.Play();
        if (winMenuCanvas)
        {
            winMenuCanvas.gameObject.SetActive(true);
        }

        // Freeze all game activity
        Time.timeScale = 0;
    }
}
