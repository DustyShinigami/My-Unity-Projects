﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HutTrigger : MonoBehaviour
{
    public GameObject[] buttonPrompts;
    public bool entranceVicinity;
    public bool exitVicinity;

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
            exitVicinity = false;
            ControllerDetection();
            if (entranceVicinity && ps4Controller == 1)
            {
                PS4Prompts();
            }
            else if (entranceVicinity && xbox360Controller == 1)
            {
                Xbox360Prompts();
            }
            else
            {
                PCPrompts();
            }
        }

        /*if (other.gameObject.CompareTag("Player") && other.gameObject.CompareTag("Pickup"))
        {
            entranceVicinity = false;
            exitVicinity = false;
            ControllerDetection();
            if (entranceVicinity && ps4Controller == 1)
            {
                PS4Prompts();
            }
            else if (entranceVicinity && xbox360Controller == 1)
            {
                Xbox360Prompts();
            }
            else
            {
                PCPrompts();
            }
        }*/
    }

    public void OnTriggerExit(Collider other)
    {
        entranceVicinity = false;
        exitVicinity = false;
    }

    public void Update()
    {
        if (entranceVicinity)
        {
            if (xbox360Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 2"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
            }
            else if (ps4Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 0"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
            }
        }
    }

    public void Hide()
    {
        buttonPrompts[0].SetActive(false);
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
                if (ps4Controller == 1)
                {
                    Debug.Log("PS4 controller detected");
                }
            }
            else if (names[x].Length == 33)
            {
                //print("XBOX 360 CONTROLLER IS CONNECTED");
                ps4Controller = 0;
                xbox360Controller = 1;
                if (xbox360Controller == 1)
                {
                    Debug.Log("Xbox 360 controller detected");
                }
            }
            else
            {
                ps4Controller = 0;
                xbox360Controller = 0;
            }

            if(xbox360Controller == 0 && ps4Controller == 0)
            {
                Debug.Log("No controllers detected");
            }

            /*if (!string.IsNullOrEmpty(names[x]))
            {
                xbox360Controller = 1;
                ps4Controller = 1;
            }

            else if(string.IsNullOrEmpty(names[x]))
            {
                xbox360Controller = 0;
                ps4Controller = 0;
                Debug.Log("Controllers not detected");
            }*/
        }
    }
}