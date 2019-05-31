using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite litCandle;

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
        }
    }

    void Update()
    {
        
    }
}
