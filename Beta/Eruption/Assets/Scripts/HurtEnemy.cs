using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damnageToGive = 10;
    public float range;
    public GameObject rayProjectile;
    public ParticleSystem projectileEffect;

    //Physics such as Raycasts are better within the FixedUpdate function as it runs in tandem with the physics
    public void FixedUpdate()
    {
        projectileEffect.Play();
        Instantiate(rayProjectile, transform.position, transform.rotation);
        RaycastHit hit;
        if(Physics.Raycast(rayProjectile.transform.position, rayProjectile.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if(target != null)
            {
                target.Damage(damnageToGive);
            }
        }
    }
}
