using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretsPickup : MonoBehaviour
{
    public int value;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddSecret(value);
            Destroy(gameObject);
        }
    }
}
