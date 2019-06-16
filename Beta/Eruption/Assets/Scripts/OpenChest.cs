using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    public GameObject chest;
    public static bool allowOpen;
    public bool secretRevealed;
    public GameObject secret;
    //public float secretSpeed;

    private Animator chestAnim;
    private Vector2 direction;

    void Awake()
    {
        chestAnim = chest.GetComponent<Animator>();
        secret.SetActive(false);
    }

    void Update()
    {
        if (secretRevealed)
        {

        }
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
            secretRevealed = true;
            secret.SetActive(true);
        }
    }
}
