using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public string exitPoint;

    private PlayerController thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            thePlayer.startPoint = exitPoint;
        }
    }
}
