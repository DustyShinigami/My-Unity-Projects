using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    //public GameObject exitPoint;
    public string exitPoint;

    private PlayerController thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            thePlayer.startPoint = exitPoint;
        }
    }
}
