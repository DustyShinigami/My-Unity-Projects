using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectileObject = Instantiate(projectilePrefab);
            projectileObject.transform.position = spawnPoint.transform.position + spawnPoint.transform.forward;
            projectileObject.transform.forward = spawnPoint.transform.forward;
        }
    }

    /*public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed = 30f;
    public float lifeTime = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            projectilePrefab.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * projectileSpeed, ForceMode.Impulse);
            //Fire();
        }
    }

    private void Fire()
    {

        //Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        //Physics.IgnoreCollision(projectilePrefab.GetComponent<Collider>(), projectileSpawn.parent.GetComponent<Collider>());
        //projectilePrefab.transform.position = projectileSpawn.position;
        //Vector3 rotation = projectilePrefab.transform.rotation.eulerAngles;
        //projectilePrefab.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        //projectilePrefab.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * projectileSpeed, ForceMode.Impulse);
        //StartCoroutine("DestroyProjectile");
    }

    private IEnumerator DestroyProjectile (GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }*/
}
