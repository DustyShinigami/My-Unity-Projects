using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    private ScreenFader theScreenFader;

    void Start()
    {
        theScreenFader = FindObjectOfType<ScreenFader>();
        ControllerDetection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7") || Input.GetKeyDown("joystick button 9"))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("start_area");
        pauseMenuUI.SetActive(false);
        theScreenFader.StartCoroutine("ScreenFade");
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControllerDetection()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            //print(names[x].Length);
            if (names[x].Length == 19)
            {
                //print("PS4 CONTROLLER IS CONNECTED");
                SceneManagement.ps4Controller = 1;
                SceneManagement.xbox360Controller = 0;
                if (SceneManagement.ps4Controller == 1)
                {
                    //Debug.Log("PS4 controller detected");
                }
            }
            else if (names[x].Length == 33)
            {
                //print("XBOX 360 CONTROLLER IS CONNECTED");
                SceneManagement.ps4Controller = 0;
                SceneManagement.xbox360Controller = 1;
                if (SceneManagement.xbox360Controller == 1)
                {
                    //Debug.Log("Xbox 360 controller detected");
                }
            }
            else
            {
                SceneManagement.ps4Controller = 0;
                SceneManagement.xbox360Controller = 0;
            }

            if (SceneManagement.xbox360Controller == 0 && SceneManagement.ps4Controller == 0)
            {
                //Debug.Log("No controllers detected");
            }
        }
    }
}
