using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private HealthManager theHealthManager;

    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            theHealthManager.SetSpawnPoint(transform.position);
        }
    }
}
