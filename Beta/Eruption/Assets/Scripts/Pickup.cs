using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject rayGun;
    public GameObject pickupLight;
    public static bool objectsDisabled = false;

    private ButtonPrompts buttonPrompts;

    void Start()
    {
        buttonPrompts = FindObjectOfType<ButtonPrompts>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.allowInteract = true;
            PlayerController.interact = true;
            buttonPrompts.ControllerDetection();
            Debug.Log("controller detection called");
            if (ButtonPrompts.ps4Controller == 1)
            {
                buttonPrompts.PS4Prompts();
            }
            else if (ButtonPrompts.xbox360Controller == 1)
            {
                buttonPrompts.Xbox360Prompts();
            }
            else
            {
                buttonPrompts.PCPrompts();
            }
        }
        /*else if (other.gameObject.CompareTag("Player"))
        {
            if (objectsDisabled)
            {
                PlayerController.allowInteract = false;
                PlayerController.interact = false;
            }
        }*/
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
        GetComponent<Collider>().enabled = false;
    }
}
