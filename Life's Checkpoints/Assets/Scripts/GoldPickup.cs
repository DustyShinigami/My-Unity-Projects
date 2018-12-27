using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

    public int value;
    public GameObject goldBar;
    public GameObject pickupEffect;
    public HealthManager healthManager;
    public Checkpoint checkpoint;

    //private Quaternion goldPosition;
    public Vector3 startPosition;

    //private Coroutine _respawnCoroutine;

    void Start()
    //To reference a method from another script in a public function, an object reference must be used. In this case, 'checkpoint'.
    //Reference a method from another script using GetComponent.
    {
        startPosition = transform.position;
        healthManager = GetComponent<HealthManager>();
        checkpoint = GetComponent<Checkpoint>();
        //goldPosition = goldBar.transform.rotation;
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
        if(checkpoint.checkpoint1On == true && healthManager.isRespawning == true)
        {
            transform.position = startPosition;
        }
        /*if (healthManager.isRespawning == true)
        {
            Destroy(goldBar);
            Instantiate(goldBar, startPosition, goldPosition);
            goldBar.transform.position = goldResp;
            goldBar.transform.rotation = goldPosition;
        }*/
    }
}