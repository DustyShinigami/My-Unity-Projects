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
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;
    public int maxHealth;
    public int healthCount;

    private bool respawning;

    void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        coinText.text = "Coins: " + coinCount;
        healthCount = maxHealth;
	}

    void Update()
    {
        if(healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
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
        healthCount = maxHealth;
        respawning = false;
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        //The text UI line needs to be added after coins have been added
        coinText.text = "Coins: " + coinCount;
    }

    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
    }
}
