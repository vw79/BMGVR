using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// (please put this script in canva component)
// Script for making button functions.

public class ButtonsFunction : MonoBehaviour
{
    // (code  what functions you want for buttons...)
    public void StartGame()
    {
        Debug.Log("Starting the game");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }

    public void ReturnScene()
    {
        string sceneName = "Prison";
        Debug.Log("Returning to the scene: " + sceneName);
        SceneManager.LoadScene(sceneName);

    }
}
