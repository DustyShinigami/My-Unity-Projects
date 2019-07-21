using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public Image blackScreen;
    public float fadeSpeed;
    public float waitForFade;
    public static bool black;

    private bool isFadeToBlack;
    private bool isFadeFromBlack;

    void Start()
    {
        StartCoroutine("ScreenFade");
    }

    IEnumerator ScreenFade()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 1"))
        {
            isFadeToBlack = false;
        }
        else if (black)
        {
            yield return new WaitForSeconds(fadeSpeed);
            isFadeToBlack = true;
            yield return new WaitForSeconds(waitForFade);
            isFadeFromBlack = true;
            //yield return new WaitForSeconds(0.1f);
        }
        else
        {
            yield return new WaitForSeconds(fadeSpeed);
            isFadeToBlack = true;
            yield return new WaitForSeconds(waitForFade);
            isFadeFromBlack = true;
            //yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }
        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }
        if (black)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b);
            if (blackScreen.color.a == 1f)
            {
                black = false;
            }
        }
    }
}
