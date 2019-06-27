using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damnageToGive = 10;
    public float range;
    public ParticleSystem projectileEffect;
    public GameObject muzzle;
    public GameObject rayGun;
    public GameObject player;

    private PlayerController playerController;

    void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    //Physics such as Raycasts are better within the FixedUpdate function as it runs in tandem with the physics
    public void FixedUpdate()
    {
        if (playerController.anim.GetCurrentAnimatorStateInfo(1).IsName("Attack"))
        {
            //Draws a green Raycast line
            Vector3 forward = muzzle.transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(muzzle.transform.position, forward, Color.green);
            projectileEffect.Play();
            RaycastHit hit;
            if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                EnemyController target = hit.transform.GetComponent<EnemyController>();
                if (target != null)
                {
                    target.Damage(damnageToGive);
                }
            }
        }
        else if (!rayGun.activeSelf)
        {
            rayGun.GetComponent<UnityEngine.EventSystems.PhysicsRaycaster>().enabled = false;
        }
    }
}
