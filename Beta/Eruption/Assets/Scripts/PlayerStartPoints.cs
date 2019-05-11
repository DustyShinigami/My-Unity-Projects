using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoints : MonoBehaviour
{
    private PlayerController thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.transform.position = transform.position;
    }

    void Update()
    {
        
    }
}
