using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPlatform : MonoBehaviour
{
    private Collider trigger1;

    void Awake()
    {
        trigger1 = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus) && other.gameObject.CompareTag("Player"))
        {
            trigger1.isTrigger = false;
        }
    }
}
