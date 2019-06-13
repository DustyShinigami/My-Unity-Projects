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
        if(Physics.Raycast(rayProjectile.transform.position, rayProjectile.transform.forward, out hit))
        {
            //Debug.Log(hit.transform.name);
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if(target != null)
            {
                target.Damage(damnageToGive);
            }
        }
    }
}
