using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public GameObject pickupEffect;

    private GameObject[] goldBar;

    void Start()
    {
        //To destroy multiple objects at once, use an Array. Then use 'GameObject.FindGameObjectsWithTag'.
        goldBar = GameObject.FindGameObjectsWithTag("Gold");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().AddGold(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    public void ResetGold()
    {
        //Using '==', 'true' and 'false' in if statements can be replaced with just the variable for 'true' and '!' at the beginning for 'false'.
        if (!FindObjectOfType<Checkpoint>().checkpoint1On)
        {
            foreach (GameObject Gold in goldBar)
            {
                {
                    Gold.SetActive(false);
                    Gold.SetActive(true);
                }
            }
        }

    }
}