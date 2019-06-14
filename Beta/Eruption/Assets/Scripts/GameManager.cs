﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public static int currentEmbers;
    public static int currentSecrets;
    public TextMeshProUGUI emberText;
    public TextMeshProUGUI secretsText;
    public bool secretCollected = false;
    public float timer = 2f;

    void Start()
    {
        secretsText.enabled = false;
    }

    void Update()
    {
        if (secretCollected)
        {
            secretsText.enabled = true;
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                secretsText.enabled = false;
            }
        }
    }

    public void AddEmber(int embertoAdd)
    {
        currentEmbers += embertoAdd;
        emberText.text = "Embers: " + currentEmbers;
    }

    public void AddSecret(int secrettoAdd)
    {
        secretCollected = true;
        currentSecrets += secrettoAdd;
        secretsText.text = "Secrets Found: " + currentSecrets;
    }
}