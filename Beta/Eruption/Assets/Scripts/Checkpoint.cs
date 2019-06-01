using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject unlitCandle;
    public GameObject litCandle;
    public ParticleSystem fireParticles;

    private bool checkpointActive;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            unlitCandle.gameObject.SetActive(false);
            litCandle.gameObject.SetActive(true);
            fireParticles.Play();
            checkpointActive = true;
        }
    }
}
