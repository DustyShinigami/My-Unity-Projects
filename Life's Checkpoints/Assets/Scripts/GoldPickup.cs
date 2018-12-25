using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

    public int value;
    public GameObject goldBar;
    public GameObject pickupEffect;
    public HealthManager healthManager;

    private Quaternion goldPosition;
    private Vector3 goldRespawnPoint;

    //private Coroutine _respawnCoroutine;

    void Start()
    //To reference a method from another script in a public function, an object reference must be used. In this case, 'checkpoint'.
    //Reference a method from another script using GetComponent.
    {
        healthManager = GetComponent<HealthManager>();
        goldRespawnPoint = goldBar.transform.position;
        goldPosition = goldBar.transform.rotation;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            FindObjectOfType<GameManager>().AddGold(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void GoldReset()
    {
        if (healthManager.isRespawning == true)
        {
            Destroy(goldBar);
            Instantiate(goldBar, goldRespawnPoint, goldPosition);
            goldBar.transform.position = goldRespawnPoint;
            goldBar.transform.rotation = goldPosition;
        }
    }
}