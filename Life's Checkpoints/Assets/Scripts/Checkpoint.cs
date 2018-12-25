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
    //public int panelID = 0;
    public GameObject[] infoPanels;

    private bool _isInCheckpoint1Area;

    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
        //infoPanels = GameObject.FindGameObjectsWithTag("InformationPanel");
        //pCPanel = GameObject.Find("PC Panel");
        //infoPanels = GameObject.FindGameObjectsWithTag("Info Panel");
        //SwitchToPanel(panelID);
        //theGameManager = FindObjectOfType<GameManager>();
    }

    public void Checkpoint1On()
    {
        if (GameManager.currentGold >= 5)
        {
            cpRenderer.material = cpOn;
            postRenderer.material = postOn;
            pcRenderer.color = new Color(1f, 1f, 1f, 1f);
            if (Input.GetKey(KeyCode.Return))
            {
                if (Input.GetKey(KeyCode.Space)) //&& !infoPanels[0].activeInHierarchy)
                {
                    Debug.Log("Panel Active");
                    infoPanels[0].SetActive(true);
                }
                else if (Input.GetKey(KeyCode.Space)) //&& infoPanels[0].activeInHierarchy)
                {
                    Debug.Log("Panel Deactivated");
                    infoPanels[0].SetActive(false);
                }
            }
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                theGameManager.Panel1();
            }*/
            //gamingPC.transform.RotateAround(transform.position, transform.up, Time.deltaTime);
            //gamingPC.transform.rotation = Quaternion.Slerp(angle, 0f, rotationSpeed * Time.deltaTime);
        }
        /*
        //[] makes a variable an Array (a list). The 'foreach' loop will check through all the Checkpoint objects
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        //For each Checkpoint Array called 'checkpoints', look for 'cp' and turn the others in the list off
        foreach (Checkpoint cp in checkpoints)
        {
            cp.CheckpointOff();
        }
        theRenderer.material = cpOn;*/
    }

    /*public void Checkpoint1Info()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            theGameManager.Panel1();
        }
    }*/

    public void Checkpoint1Off()
    {
        cpRenderer.material = cpOff;
        postRenderer.material = postOff;
        pcRenderer.color = new Color(1f, 1f, 1f, 5f);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isInCheckpoint1Area = true;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            theHealthManager.SetSpawnPoint(transform.position);
            Checkpoint1On();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isInCheckpoint1Area = false;
        }
    }
}
