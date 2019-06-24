using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public string levelToLoad;
    public GameObject buttons;
    public GameObject title;

    void Start()
    {
        StartCoroutine("MainMenuManager");
    }

    IEnumerator MainMenuManager()
    {
        yield return new WaitForSeconds(2f);
        title.SetActive(true);
        buttons.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
