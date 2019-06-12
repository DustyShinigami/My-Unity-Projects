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
    private HealthManager theHealthManager;

    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
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
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 2"))
        {
            StartCoroutine("ScreenFade");
        }
        else
        {
            StartCoroutine("ScreenFade");
        }
    }

    IEnumerator ScreenFade()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("main_menu"))
        {
            yield return new WaitForSeconds(fadeSpeed);
            isFadetoBlack = true;
            yield return new WaitForSeconds(waitForFade);
            isFadefromBlack = true;
            yield return new WaitForSeconds(2f);
            blackScreen.enabled = false;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 1"))
        {
            isFadetoBlack = false;
        }
        else
        {
            blackScreen.enabled = true;
            yield return new WaitForSeconds(fadeSpeed);
            isFadetoBlack = true;
            yield return new WaitForSeconds(waitForFade);
            isFadefromBlack = true;
            yield return new WaitForSeconds(2f);
        }
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
