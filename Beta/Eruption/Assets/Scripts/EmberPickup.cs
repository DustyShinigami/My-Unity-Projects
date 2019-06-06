using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberPickup : MonoBehaviour {

    public int value;
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddEmber(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}