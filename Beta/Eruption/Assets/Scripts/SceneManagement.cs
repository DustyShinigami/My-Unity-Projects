using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public bool entranceVicinity;
    public bool exitVicinity;
    public string levelToLoad;
    public GameObject exitLight;
    public static bool insideHut;
    public static bool outsideHut;
    public static bool backOutsideHut;

    private PlayerController thePlayer;
    private ButtonPrompts buttonPrompts;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        buttonPrompts = FindObjectOfType<ButtonPrompts>();
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
                buttonPrompts.ControllerDetection();
                if (entranceVicinity && ButtonPrompts.ps4Controller == 1)
                {
                    buttonPrompts.PS4Prompts();
                }
                else if (entranceVicinity && ButtonPrompts.xbox360Controller == 1)
                {
                    buttonPrompts.Xbox360Prompts();
                }
                else
                {
                    buttonPrompts.PCPrompts();
                }
            }
        }
        if (Pickup.objectsDisabled && NPC.leverActivated && insideHut)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                entranceVicinity = false;
                exitVicinity = true;
                buttonPrompts.ControllerDetection();
                if (exitVicinity && ButtonPrompts.ps4Controller == 1)
                {
                    buttonPrompts.PS4Prompts();
                }
                else if (exitVicinity && ButtonPrompts.xbox360Controller == 1)
                {
                    buttonPrompts.Xbox360Prompts();
                }
                else
                {
                    buttonPrompts.PCPrompts();
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
            if (ButtonPrompts.xbox360Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 2"))
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
            else if (ButtonPrompts.ps4Controller == 1)
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
            if (ButtonPrompts.xbox360Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 2"))
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
            else if (ButtonPrompts.ps4Controller == 1)
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
        if (Pickup.objectsDisabled && NPC.leverActivated && insideHut)
        {
            exitLight.SetActive(true);
        }
    }
}