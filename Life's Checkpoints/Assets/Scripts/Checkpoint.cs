using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public HealthManager theHealthManager;
    public Renderer cpRenderer;
    public Renderer postRenderer;
    public SpriteRenderer pcRenderer;
    public Material cpOff;
    public Material cpOn;
    public Material postOff;
    public Material postOn;
    public GameObject[] infoPanels;
    public bool checkpoint1On;

    //Make sure to assign a value to a bool with '=' and in an 'if' statement somewhere in the code to prevent warnings.
    private bool checkpoint1IsActivated;
    private bool infoPanel1Activated;

    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
    }

    public void Checkpoint1On()
    {
        cpRenderer.material = cpOn;
        postRenderer.material = postOn;
        pcRenderer.color = new Color(1f, 1f, 1f, 1f);
        checkpoint1On = true;
    }

    /*if (Input.GetKeyDown(KeyCode.Space) && !infoPanels[0].activeInHierarchy)
    {
        Debug.Log("Panel Active");
        infoPanels[0].SetActive(true);
    }
    else if (Input.GetKeyDown(KeyCode.Space) && infoPanels[0].activeInHierarchy)
    {
        Debug.Log("Panel Deactivated");
        infoPanels[0].SetActive(false);
    }

    //[] makes a variable an Array (a list). The 'foreach' loop will check through all the Checkpoint objects
    Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
    //For each Checkpoint Array called 'checkpoints', look for 'cp' and turn the others in the list off
    foreach (Checkpoint cp in checkpoints)
    {
        cp.CheckpointOff();
    }
    theRenderer.material = cpOn;*/

    public void Checkpoint1Off()
    {
        cpRenderer.material = cpOff;
        postRenderer.material = postOff;
        pcRenderer.color = new Color(1f, 1f, 1f, 5f);
        checkpoint1On = false;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.currentGold >= 5)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    checkpoint1IsActivated = true;
                    theHealthManager.SetSpawnPoint(transform.position);
                    Checkpoint1On();
                }
            }
            else if (GameManager.currentGold <= 5)
            {
                checkpoint1IsActivated = false;
            }
        }
        if (checkpoint1IsActivated)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (infoPanel1Activated)
                {
                    Debug.Log("Panel Active");
                    infoPanels[0].SetActive(false);
                    infoPanel1Activated = false;
                }
                else
                {
                    Debug.Log("Panel Deactivated");
                    infoPanels[0].SetActive(true);
                    infoPanel1Activated = true;
                }
            }
        }
    }
}
