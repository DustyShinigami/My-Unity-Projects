using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;

    private LevelManager theLevelManager;

    public void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            theLevelManager.AddCoins(coinValue);
        }
    }
}
