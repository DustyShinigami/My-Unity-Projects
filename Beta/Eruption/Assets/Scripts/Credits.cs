using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public TextMeshProUGUI[] creditsText;
    public float fadeSpeed;
    public GameObject restartButton;
    public GameObject quitButton;

    private bool fadeToWhite;
    private bool fadeFromBlack;

    void Start()
    {
        StartCoroutine("CreditsManager");
    }

    void Update()
    {
        if (fadeToWhite)
        {
            creditsText[0].color = new Color(creditsText[0].color.r, creditsText[0].color.g, creditsText[0].color.b, Mathf.MoveTowards(creditsText[0].color.a, 1f, fadeSpeed * Time.deltaTime));
            creditsText[1].color = new Color(creditsText[1].color.r, creditsText[1].color.g, creditsText[1].color.b, Mathf.MoveTowards(creditsText[1].color.a, 1f, fadeSpeed * Time.deltaTime));
            creditsText[2].color = new Color(creditsText[2].color.r, creditsText[2].color.g, creditsText[2].color.b, Mathf.MoveTowards(creditsText[2].color.a, 1f, fadeSpeed * Time.deltaTime));
            if (creditsText[0].color.a == 1f && creditsText[1].color.a == 1f && creditsText[2].color.a == 1f)
            {
                fadeToWhite = true;
            }
        }
        if (fadeFromBlack)
        {
            creditsText[0].color = new Color(creditsText[0].color.r, creditsText[0].color.g, creditsText[0].color.b, Mathf.MoveTowards(creditsText[0].color.a, 0f, fadeSpeed * Time.deltaTime));
            creditsText[1].color = new Color(creditsText[1].color.r, creditsText[1].color.g, creditsText[1].color.b, Mathf.MoveTowards(creditsText[1].color.a, 0f, fadeSpeed * Time.deltaTime));
            creditsText[2].color = new Color(creditsText[2].color.r, creditsText[2].color.g, creditsText[2].color.b, Mathf.MoveTowards(creditsText[2].color.a, 0f, fadeSpeed * Time.deltaTime));
            if (creditsText[0].color.a == 0f && creditsText[1].color.a == 0f && creditsText[2].color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    IEnumerator CreditsManager()
    {
        yield return new WaitForSeconds(fadeSpeed);
        fadeFromBlack = true;
        yield return new WaitForSeconds(fadeSpeed);
        fadeToWhite = true;
        restartButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("start_area");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
