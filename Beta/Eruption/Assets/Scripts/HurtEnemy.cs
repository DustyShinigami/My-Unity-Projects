using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damnageToGive = 10;
    public float range;
    public ParticleSystem projectileEffect;

    private void OnTriggerEnter(Collider other)
    {
        print("hit " + other.name + "!");
        Destroy(gameObject);
    }

    //Physics such as Raycasts are better within the FixedUpdate function as it runs in tandem with the physics
    /*public void FixedUpdate()
    {
        projectileEffect.Play();
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if(target != null)
            {
                target.Damage(damnageToGive);
            }
        }
    }*/
}
