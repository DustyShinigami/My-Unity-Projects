using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public HealthManager theHealthManager;
    public Renderer theRenderer;
    public Material cpOff;
    public Material cpOn;

	void Start ()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
	}

    public void CheckpointOn()
    {
        //[] makes a variable an Array (a list). The 'foreach' loop will check through all the Checkpoint objects
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        //For each Checkpoint Array called 'checkpoints', look for 'cp' and turn the others in the list off
        foreach(Checkpoint cp in checkpoints)
        {
            cp.CheckpointOff();
        }
        theRenderer.material = cpOn;
    }

    public void CheckpointOff()
    {
        theRenderer.material = cpOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            theHealthManager.SetSpawnPoint(transform.position);
            CheckpointOn();
        }
    }
}
