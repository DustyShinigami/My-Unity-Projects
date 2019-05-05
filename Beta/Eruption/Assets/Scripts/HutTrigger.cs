using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HutTrigger : MonoBehaviour
{
    public static bool hutLoaded;
    public GameObject[] buttonPrompts;
    public bool entranceVicinity;

    private int xbox360Controller = 0;
    private int ps4Controller = 0;

    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            entranceVicinity = true;
            ControllerDetection();
        }
    }

    void Update()
    {
        if (entranceVicinity)
        {
            if(xbox360Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 2"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                    hutLoaded = true;
                }
            }
            else if(ps4Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 0"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                    hutLoaded = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                    hutLoaded = true;
                }
            }
        }
    }

    public void Hide()
    {
        buttonPrompts[0].SetActive (false);
        buttonPrompts[1].SetActive(false);
        buttonPrompts[2].SetActive(false);
    }

    public void Xbox360Prompts()
    {
        buttonPrompts[1].SetActive(true);
        Invoke("Hide", 3f);
    }

    public void PS4Prompts()
    {
        buttonPrompts[2].SetActive(true);
        Invoke("Hide", 3f);
    }

    public void PCPrompts()
    {
        buttonPrompts[0].SetActive(true);
        Invoke("Hide", 3f);
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
                ps4Controller = 1;
                xbox360Controller = 0;
            }
            if (names[x].Length == 33)
            {
                //print("XBOX 360 CONTROLLER IS CONNECTED");
                ps4Controller = 0;
                xbox360Controller = 1;
            }
            if (xbox360Controller == 1)
            {
                Xbox360Prompts();
            }
            else if (ps4Controller == 1)
            {
                PS4Prompts();
            }
            else
            {
                PCPrompts();
            }
        }
    }
}