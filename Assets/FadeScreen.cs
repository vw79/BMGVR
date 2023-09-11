using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = false;
    public float fadeDuration = 2f;
    public Color fadeColor;
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        Fade(1, 0);
    }

    public void FadeOut()
    {
        gameObject.SetActive(true);
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0f;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }
        if (alphaOut == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
