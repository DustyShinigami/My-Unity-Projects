using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string exitPoint;

    private PlayerController thePlayer;
    private PlayerStartPoints startPoints;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        startPoints = FindObjectOfType<PlayerStartPoints>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            thePlayer.startPoint = exitPoint;
            startPoints.NewArea();
        }
    }
}
