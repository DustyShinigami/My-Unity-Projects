using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{

    public int value;
    public GameObject pickupEffect;
    public GameObject[] goldBar;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            FindObjectOfType<GameManager>().AddGold(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void DestroyGold()
    {
        //For Statics, an object reference isn't necessary. Use the FindObjectOfType to find the appropriate script and reference the Type, such as HealthManager.
        if (Checkpoint.checkpoint1On == false)
        {
            foreach (GameObject Gold in goldBar)
            {
                Debug.Log("Gold Destroyed");
                Destroy(Gold);
            }
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

    /*public void GoldReset()
    {
        if (checkpoint.checkpoint1On == false)
        {
            Instantiate(goldDestroy.goldBar[5], respawnPoint, startPosition);
            transform.position = respawnPoint;
            transform.rotation = startPosition;
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