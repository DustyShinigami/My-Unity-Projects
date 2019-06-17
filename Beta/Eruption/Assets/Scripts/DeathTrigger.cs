using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public static bool instaKill;

    private int damnageToGive = 30;
    private ScreenFader theScreenFader;

    void Awake()
    {
        theScreenFader = FindObjectOfType<ScreenFader>();
    }

    void Start()
    {
        //To reference a method in another script, such as the GameManager in this case, be sure to use the type name if it's to be used in a private method.
        //checkpoint = FindObjectOfType<Checkpoint>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            instaKill = true;
            if (!Checkpoint.checkpointActive)
            {
                Debug.Log("this");
                Vector3 hitDirection = other.transform.position - transform.position;
                hitDirection = hitDirection.normalized;
                FindObjectOfType<HealthManager>().HurtPlayer(damnageToGive, hitDirection);
                theScreenFader.StartCoroutine("ScreenFade");
            }
            else
            {
                Debug.Log("that");
                Vector3 hitDirection = other.transform.position - transform.position;
                hitDirection = hitDirection.normalized;
                FindObjectOfType<HealthManager>().HurtPlayer(damnageToGive, hitDirection);
                //theScreenFader.StartCoroutine("ScreenFade");
            }
        }
    }
}