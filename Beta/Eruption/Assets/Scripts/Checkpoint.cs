using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject unlitCandle;
    public GameObject litCandle;
    public GameObject fireParticles;
    public static bool checkpointActive;
    //public HealthManager theHealthManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            unlitCandle.gameObject.SetActive(false);
            litCandle.gameObject.SetActive(true);
            Instantiate(fireParticles, transform.position, transform.rotation);
            checkpointActive = true;
            //theHealthManager.SetSpawnPoint(transform.position);
        }
    }
}
