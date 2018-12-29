﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{

    public int value;
    public GameObject thePlayer;
    public GameObject goldBar;
    public GameObject pickupEffect;
    public HealthManager healthManager;
    public Checkpoint checkpoint;

    //private Quaternion goldPosition;
    private Vector3 respawnPoint;
    private Quaternion startPosition;

    private Coroutine _respawnCoroutine;

    void Start()
    //To reference a method from another script in a public function, an object reference must be used. In this case, 'checkpoint'.
    //Reference a method from another script using GetComponent.
    {
        respawnPoint = transform.position;
        startPosition = transform.rotation;
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

    /*if(healthManager.isRespawning == true)
    {
        if (checkpoint.checkpoint1On == false)
        {
            StartCoroutine("GoldRespawnCo");
        }
    }

    else if(_respawnCoroutine != null)
    {
        StopCoroutine(_respawnCoroutine);
        _respawnCoroutine = StartCoroutine("GoldRespawnCo");
    }
}
public IEnumerator GoldRespawnCo()*/
    public void GoldReset()
    {
        Destroy(gameObject);
        transform.position = respawnPoint;
        transform.rotation = startPosition;
        /*if (thePlayer.gameObject.activeInHierarchy == false)
        {
            Destroy(gameObject);
            Instantiate(goldBar, transform.position, transform.rotation);
        }
        else
        {
            if (thePlayer.gameObject.activeInHierarchy == true)
            {
                transform.position = respawnPoint;
                transform.rotation = startPosition;
            }
        }*/
    }
}