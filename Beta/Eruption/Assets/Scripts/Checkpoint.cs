using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject unlitCandle;
    public GameObject litCandle;
    public GameObject fireParticles;
    public static bool checkpointActive;
    public HealthManager theHealthManager;
    public Transform checkpointZone;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            unlitCandle.gameObject.SetActive(false);
            litCandle.gameObject.SetActive(true);
            Instantiate(fireParticles, litCandle.transform.position, litCandle.transform.rotation);
            checkpointActive = true;
        }
        else
        {
            checkpointActive = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(checkpointActive)
        {
            theHealthManager.SetSpawnPoint(checkpointZone.transform.position);
        }
    }
}
