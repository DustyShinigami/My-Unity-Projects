using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject rayGun;
    public bool allowInteract = false;

    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            allowInteract = true;
            PlayerController.interact = true;
        }
    }

    void Update()
    {
        if (allowInteract)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rayGun.SetActive(false);
            }
        }
    }
}
