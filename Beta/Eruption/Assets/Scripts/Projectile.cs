using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
   
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    /*public Transform startPoint;
    //public Rigidbody rb;
    public Rigidbody projectile;
    public GameObject projectileObject;
    //public GameObject rayGun;
    public float projectileSpeed;
    //public GameObject player;

    //private Animator playerAnim;

    void Start()
    {
        projectile = projectileObject.GetComponent<Rigidbody>();
        //projectileObject.SetActive(false);
        //playerAnim = player.GetComponent<Animator>();
    }

    public void Fire()
    {
        projectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed));
        Instantiate(projectile, transform.position, transform.rotation);
    }

    public void Fire()
    {
        rb.transform.position = points[0].transform.position;
        rb.velocity = transform.forward * projectileSpeed;
        transform.Translate(transform.right * projectileSpeed * Time.smoothDeltaTime);
        if (rb.transform.position == points[1].transform.position)
    }

    void Update()
    {
        //projectile.transform.position = startPoint.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //projectileObject.SetActive(true);
            //projectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed));
            //Instantiate(projectile, transform.position, transform.rotation);
            //Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed));
        }
    }*/
}

