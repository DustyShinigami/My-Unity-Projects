﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;

    private LevelManager theLevelManager;

    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        theLevelManager.HurtPlayer(damageToGive);
        //theLevelManager.Respawn();
    }
}
