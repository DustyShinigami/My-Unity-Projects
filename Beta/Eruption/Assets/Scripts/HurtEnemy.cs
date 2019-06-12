using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damnageToGive = 10;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Enemy"))
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<EnemyController>().HurtEnemy(damnageToGive, hitDirection);
            Debug.Log("Enemy hit");
        }
    }
}
