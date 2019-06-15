using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public Checkpoint checkpoint;
    public HealthManager theHealthManager;
    public static bool instaKill;
    public GameObject thePlayer;

    private int damnageToGive;

    void Start()
    {
        //To reference a method in another script, such as the GameManager in this case, be sure to use the type name if it's to be used in a private method.
        //checkpoint = FindObjectOfType<Checkpoint>();
    }

    public void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Player")
        {
            instaKill = true;
            thePlayer.SetActive(false);
            if (!Checkpoint.checkpointActive)
            {
                StartCoroutine("Timer");
            }
            else if (Checkpoint.checkpointActive)
            {
                theHealthManager.StartCoroutine("RespawnCo");
            }
            //theHealthManager.StartCoroutine("RespawnCo");
            /*damnageToGive -= theHealthManager.currentHealth;
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damnageToGive, hitDirection);*/
        /*else if (Checkpoint.checkpointActive)
        {
            Debug.Log("Checkpoint is active")
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damnageToGive, hitDirection);
            //checkpoint.OnTriggerStay(other);
        }*/
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}