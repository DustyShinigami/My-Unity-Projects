using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damnageToGive = 10;
    public float range;
    public ParticleSystem projectileEffect;
    public Transform gunMuzzle;

    private void FixedUpdate()
    {
        transform.position = gunMuzzle.transform.position + gunMuzzle.transform.forward;
        transform.forward = gunMuzzle.transform.forward;
        transform.position += transform.right * range * Time.deltaTime;
    }

    //Draws a green Raycast line
    /*void Update()
    {
        Vector3 forward = gunMuzzle.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    //Physics such as Raycasts are better within the FixedUpdate function as it runs in tandem with the physics
    public void FixedUpdate()
    {
        projectileEffect.Play();
        RaycastHit hit;
        if(Physics.Raycast(gunMuzzle.transform.position, gunMuzzle.transform.forward, out hit, range))
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
