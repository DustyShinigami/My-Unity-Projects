using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    //private PlayerController thePlayer;
    public GameObject projectilePrefab;

    void Awake()
    {
        //thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //if (thePlayer.anim.GetCurrentAnimatorStateInfo(1).IsName("Attack"))
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectileObject = Instantiate(projectilePrefab);
        }
    }

    /*public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Physics.IgnoreCollision(projectilePrefab.GetComponent<Collider>(), spawnPoint.parent.GetComponent<Collider>());
            Fire();
        }
    }

    public void Fire()
    {
        GameObject projectileObject = Instantiate(projectilePrefab);
        Physics.IgnoreCollision(projectileObject.GetComponent<Collider>(), projectileSpawn.parent.parent.GetComponent<Collider>());
        projectileObject.transform.position = projectileSpawn.position;
        Vector3 rotation = projectilePrefab.transform.rotation.eulerAngles;
        projectileObject.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectileObject.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * projectileSpeed, ForceMode.Impulse);
        StartCoroutine("DestroyProjectile");
    }

    public IEnumerator DestroyProjectile(GameObject projectileObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("destroyed");
        Destroy(projectileObject);
    }*/
    //GameObject projectileObject = Instantiate(projectilePrefab);
    //projectileObject.transform.position = spawnPoint.transform.position + spawnPoint.transform.forward;
    //projectileObject.transform.forward = spawnPoint.transform.forward;
    //projectilePrefab.transform.position += transform.right * speed * Time.deltaTime;*/

    /*public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed = 30f;
    public float lifeTime = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            //projectilePrefab.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * projectileSpeed, ForceMode.Impulse);
            Fire();
        }
    }

    private void Fire()
    {
        GameObject projectileObject = Instantiate(projectilePrefab);
        //Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        Physics.IgnoreCollision(projectileObject.GetComponent<Collider>(), projectileSpawn.parent.GetComponent<Collider>());
        projectileObject.transform.position = projectileSpawn.position;
        Vector3 rotation = projectilePrefab.transform.rotation.eulerAngles;
        projectileObject.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectileObject.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * projectileSpeed, ForceMode.Impulse);
        StartCoroutine("DestroyProjectile");
    }

    private IEnumerator DestroyProjectile (GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }*/
}
