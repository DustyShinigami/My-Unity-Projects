using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestTrigger : MonoBehaviour
{
    BoxCollider triggerCollider;
    public GameObject controllerManager;
    public GameObject chestObject;
    public static bool allowOpen;
    public GameObject blueSecret;

    private Animator chestAnim;
    private SecretsPickup pickupSecret;
    private ControllerManager theControllerManager;
    private Chest chestScript;

    void Awake()
    {
        chestAnim = chestObject.GetComponent<Animator>();
        pickupSecret = blueSecret.GetComponent<SecretsPickup>();
        theControllerManager = controllerManager.GetComponent<ControllerManager>();
        chestScript = chestObject.GetComponent<Chest>();
        triggerCollider = GetComponent<BoxCollider>();
        blueSecret.SetActive(false);
        allowOpen = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            allowOpen = true;
            theControllerManager.ControllerDetection();
            if(allowOpen && ControllerManager.xbox360Controller == 1)
            {
                theControllerManager.Xbox360Prompts();
            }
            else if(allowOpen && ControllerManager.ps4Controller == 1)
            {
                theControllerManager.PS4Prompts();
            }
            else
            {
                theControllerManager.PCPrompts();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        allowOpen = false;
    }

    public void ChestOpen()
    {
        if (allowOpen)
        {
            chestAnim.SetBool("canOpen", true);
            chestAnim.SetTrigger("open");
            blueSecret.SetActive(true);
            pickupSecret.Secret();
            if (blueSecret.activeSelf)
            {
                chestScript.ChestCollider();
                allowOpen = false;
                triggerCollider.enabled = false;
            }
        }
    }
}
