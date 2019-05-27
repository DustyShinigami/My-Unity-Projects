﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public GameObject[] buttonPrompts;
    public bool entranceVicinity;
    public bool exitVicinity;
    public string levelToLoad;
    public static int xbox360Controller = 0;
    public static int ps4Controller = 0;
    public GameObject exitLight;
    public bool backOutsideHut;

    private bool outsideHut;
    private bool insideHut;
    private PlayerController thePlayer;
    private ScreenFader theScreenFader;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theScreenFader = FindObjectOfType<ScreenFader>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area"))
        {
            outsideHut = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
        {
            insideHut = true;
            outsideHut = false;
            exitLight.SetActive(false);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area 2"))
        {
            backOutsideHut = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (outsideHut)
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
        }
        else if (Pickup.objectsDisabled && NPC.leverActivated && insideHut)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                entranceVicinity = false;
                exitVicinity = true;
                exitLight.SetActive(true);
                ControllerDetection();
                if (exitVicinity && ps4Controller == 1)
                {
                    PS4Prompts();
                }
                else if (exitVicinity && xbox360Controller == 1)
                {
                    Xbox360Prompts();
                }
                else
                {
                    PCPrompts();
                }
            }
        }
        else if(backOutsideHut)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
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
                    SceneManager.LoadScene(levelToLoad);
                }
            }
            else if (ps4Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 0"))
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
        }
        else if (exitVicinity)
        {
            if (xbox360Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 2"))
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
            else if (ps4Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 0"))
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(levelToLoad);
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
                    //Debug.Log("PS4 controller detected");
                }
            }
            else if (names[x].Length == 33)
            {
                //print("XBOX 360 CONTROLLER IS CONNECTED");
                ps4Controller = 0;
                xbox360Controller = 1;
                if (xbox360Controller == 1)
                {
                    //Debug.Log("Xbox 360 controller detected");
                }
            }
            else
            {
                ps4Controller = 0;
                xbox360Controller = 0;
            }

            if(xbox360Controller == 0 && ps4Controller == 0)
            {
                //Debug.Log("No controllers detected");
            }
        }
    }
}