using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public bool isDead { get; private set; }

    private void Start()
    {
        isDead = false;
    }

    private void Update()
    {

    }



    public void OnDeath()
    {
        isDead = true;
        GameManager.instance.GoToScene(2);
        //fadeScreen.FadeIn();
        //StartCoroutine(gameOver());
    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(fadeScreen.fadeDuration + 1);
        SceneManager.LoadScene(2);
    }
}
