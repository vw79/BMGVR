using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Image image;
    private bool isDead = false;

    private void Start()
    {
        image = GameObject.Find("Dead Screen").GetComponent<Image>();
    }

    private void Update()
    {
        if(!isDead)
        {
            return;
        }

        if(image != null)
        {
              image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.6f * Time.deltaTime);
        }

        if(image.color.a >= 1f)
        {
            SceneManager.LoadScene("DeadScreen");
        }
    }

    public void OnDeath()
    {
        isDead = true;
    }
}
