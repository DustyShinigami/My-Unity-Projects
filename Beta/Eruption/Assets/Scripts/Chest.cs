using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject controllerManager;
    public GameObject chest;
    public static bool allowOpen;
    public GameObject blueSecret;

    private Animator chestAnim;
    private SecretsPickup pickupSecret;
    private ControllerManager theControllerManager;

    void Awake()
    {
        chestAnim = chest.GetComponent<Animator>();
        pickupSecret = blueSecret.GetComponent<SecretsPickup>();
        theControllerManager = controllerManager.GetComponent<ControllerManager>();
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
                allowOpen = false;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
