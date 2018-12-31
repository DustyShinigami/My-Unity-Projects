using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public GameObject pickupEffect;
    public GameObject[] goldBar;
    public GameObject goldBars;
    public HealthManager healthManager;
    public Checkpoint checkpoint;
    //public GameObject goldPrefab;
    //public GameObject thisGold;

    private Vector3 goldStartPosition;
    //private Quaternion goldStartPosition;
    //private GameObject[] goldBar;

    void Start()
    {
        //To destroy multiple objects at once, use FindGameObjectsWithTag.
        //GetComponent is considered more efficient than FindObjectOfType, but the latter avoids any errors saying an object reference hasn't been set.
        goldBar = GameObject.FindGameObjectsWithTag("Gold");
        healthManager = FindObjectOfType<HealthManager>();
        //FindObjectOfType<Checkpoint>();
        checkpoint = FindObjectOfType<Checkpoint>();
        goldStartPosition = transform.position;
        //goldStartPosition = transform.rotation;
        //thisGold = Instantiate(goldPrefab) as GameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().AddGold(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void DestroyGold()
    {
        //For Statics, an object reference isn't necessary. Use the FindObjectOfType to find the appropriate script and reference the Type, such as HealthManager.
        if (checkpoint.checkpoint1On == false)
        {
            foreach (GameObject Gold in goldBar)
            {
                Destroy(Gold);
                Debug.Log("Gold Destroyed");
                Instantiate(goldBars, goldStartPosition, Quaternion.identity);
                Debug.Log("Gold Instantiated");
                goldStartPosition = transform.position;
                //goldStartPosition = transform.rotation;
                //healthManager.RespawnCo();
            }
        }

    }
    /*public void GoldReset()
    {
        if (healthManager.isRespawning == true)
        {
            if (checkpoint.checkpoint1On == false)
            {
                StartCoroutine("GoldRespawnCo");
            }
        }

        else if (_respawnCoroutine != null)
        {
            StopCoroutine(_respawnCoroutine);
            _respawnCoroutine = StartCoroutine("GoldRespawnCo");
        }*/

    /*public IEnumerator GoldRespawnCo()
    {
        if (checkpoint.checkpoint1On == false)
        {
            Instantiate(goldPrefab, goldRespawnPoint, goldStartPosition);
            transform.position = goldRespawnPoint;
            transform.rotation = goldStartPosition;
        }
        else
        {
            yield return null;
        }
    }*/

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