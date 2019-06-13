using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damnageToGive = 10;
    public float range = 50;
    public GameObject rayGun;

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(rayGun.transform.position, rayGun.transform.forward, out hit, range))
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
