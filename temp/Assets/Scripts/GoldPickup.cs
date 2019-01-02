using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public GameObject pickupEffect;
    //public GameObject[] goldBarArray;
    //public GameObject goldBarPrefab;
    //public GameObject goldBarPrefabClone;

    //private Vector3 startPosition;

    void Start()
    {
        //To destroy multiple objects at once, use an Array. Then use 'GameObject.FindGameObjectsWithTag'.
        //goldBarArray = GameObject.FindGameObjectsWithTag("Gold");
        //startPosition = transform.position;
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

    /*public void DestroyGold()
    {
        //Using '==', 'true' and 'false' in if statements can be replaced with just the variable for 'true' and '!' at the beginning for 'false'.
        if (!FindObjectOfType<Checkpoint>().checkpoint1On)
        {
            foreach (GameObject Gold in goldBarArray)
            {
                {
                    Destroy(Gold);
                }
            }
        }

    }

    public void ResetGold()
    {
        goldBarPrefabClone = Instantiate(goldBarPrefab, transform.position, Quaternion.identity) as GameObject;
    }*/
}