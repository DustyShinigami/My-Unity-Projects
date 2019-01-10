using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public PlayerController thePlayer;
    public float waitToSpawn;
    public GameObject deathEffect;

	void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

	public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        GameObject particlesGameObject = Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);
        particlesGameObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(waitToSpawn);
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }
}
