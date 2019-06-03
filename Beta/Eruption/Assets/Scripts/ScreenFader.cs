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

    private bool isFadetoBlack;
    private bool isFadefromBlack;

    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("main_menu"))
        {
            StartCoroutine("ScreenFade");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area"))
        {
            StartCoroutine("ScreenFade");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
        {
            StartCoroutine("ScreenFade");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area 2"))
        {
            StartCoroutine("ScreenFade");
        }
    }

    IEnumerator ScreenFade()
    {
        yield return new WaitForSeconds(fadeSpeed);
        isFadetoBlack = true;
        yield return new WaitForSeconds(waitForFade);
        isFadefromBlack = true;
        yield return new WaitForSeconds(1f);
        blackScreen.enabled = false;
    }

    void Update()
    {
        if (isFadetoBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadetoBlack = false;
            }
        }
        if (isFadefromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadefromBlack = true;
            }
        }
    }
}
