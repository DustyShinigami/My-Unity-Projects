using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberPickup : MonoBehaviour {

    public int value;
    public GameObject pickupEffect;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            FindObjectOfType<GameManager>().AddEmber(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}