using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public PlayerController thePlayer;
    public float waitToSpawn;
    public GameObject deathEffect;
    public int coinCount;
    public Text coinText;

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
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(waitToSpawn);
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        //The text UI line needs to be added after coins have been added
        coinText.text = "Coins: " + coinCount;
    }
}
