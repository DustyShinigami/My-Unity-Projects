using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTrigger : MonoBehaviour
{
    public int damnageToGive = 10;
    public Checkpoint checkpoint;

    void Start()
    {
        //To reference a method in another script, such as the GameManager in this case, be sure to use the type name if it's to be used in a private method.
        checkpoint = FindObjectOfType<Checkpoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damnageToGive, hitDirection);
        }
        else if (GameManager.currentGold >= 5)
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damnageToGive, hitDirection);
            checkpoint.OnTriggerEnter(other);
        }
    }
}