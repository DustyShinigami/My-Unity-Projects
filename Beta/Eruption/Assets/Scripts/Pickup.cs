using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject[] buttonPrompts;
    public GameObject rayGun;
    public GameObject pickupLight;
    public bool objectsDisabled = false;

    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.allowInteract = true;
            PlayerController.interact = true;
            ControllerDetection();
            if (SceneManagement.ps4Controller == 1)
            {
                PS4Prompts();
            }
            else if (SceneManagement.xbox360Controller == 1)
            {
                Xbox360Prompts();
            }
            else
            {
                PCPrompts();
            }
        }
        else
        {
            if (objectsDisabled)
            {
                PlayerController.allowInteract = false;
                PlayerController.interact = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerController.allowInteract = false;
        PlayerController.interact = false;
    }

    public void ObjectActivation()
    {
        rayGun.SetActive(false);
        pickupLight.SetActive(false);
        objectsDisabled = true;
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
        if (objectsDisabled)
        {
            buttonPrompts[1].SetActive(false);
        }
    }

    public void PS4Prompts()
    {
        buttonPrompts[2].SetActive(true);
        Invoke("Hide", 3f);
        if (objectsDisabled)
        {
            buttonPrompts[2].SetActive(false);
        }
    }

    public void PCPrompts()
    {
        buttonPrompts[0].SetActive(true);
        Invoke("Hide", 3f);
        if (objectsDisabled)
        {
            buttonPrompts[0].SetActive(false);
        }
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
