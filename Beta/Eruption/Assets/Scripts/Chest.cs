using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject chest;
    public static bool allowOpen;
    public GameObject blueSecret;

    private Animator chestAnim;
    private SecretsPickup pickupSecret;

    void Awake()
    {
        chestAnim = chest.GetComponent<Animator>();
        pickupSecret = blueSecret.GetComponent<SecretsPickup>();
        blueSecret.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            allowOpen = true;
        }
    }

    public void ChestOpen()
    {
        if (allowOpen)
        {
            chestAnim.SetBool("canOpen", true);
            chestAnim.SetTrigger("open");
            blueSecret.SetActive(true);
            pickupSecret.StartCoroutine("SecretReveal");
        }
    }
}
