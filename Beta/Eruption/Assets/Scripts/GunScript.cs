using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    public void Start()
    {
        projectile.SetActive(false);
    }

    public void Fire()
    {
        projectile.SetActive(true);
    }

}
