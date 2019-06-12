using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damnageToGive = 10;
    public float range = 50;
    public GameObject rayProjectile;

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(rayProjectile.transform.position, rayProjectile.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }

    /*private EnemyController theEnemy;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            //GetComponent will get a component on the current GameObject the script is attached to. To get a component on a different object, a reference will need to be made, such as below.
            theEnemy.GetComponent<EnemyController>().HurtEnemy(damnageToGive, hitDirection);
            Debug.Log("Enemy hit");
        }
    }*/
}
