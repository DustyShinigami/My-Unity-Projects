using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public HealthManager theHealthManager;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            theHealthManager.SetSpawnPoint(transform.position);
        }
    }
}
