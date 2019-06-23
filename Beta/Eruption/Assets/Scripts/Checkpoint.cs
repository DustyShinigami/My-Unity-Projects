using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject unlitCandle;
    public GameObject litCandle;
    public GameObject fireParticles;
    public static bool checkpointActive;

    void Start()
    {
        unlitCandle.gameObject.SetActive(true);
        checkpointActive = false;
    }

    public void OnTriggerEnter (Collider other)
    {
        unlitCandle.gameObject.SetActive(false);
        litCandle.gameObject.SetActive(true);
        Instantiate(fireParticles, litCandle.transform.position, litCandle.transform.rotation);
        checkpointActive = true;
    }
}
