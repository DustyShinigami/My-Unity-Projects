using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int currentEmbers;
    public static int currentSecrets;
    public TextMeshProUGUI emberText;
    public TextMeshProUGUI secretsText;

    private bool secretCollected = false;
    private float timer = 2f;

    void Awake()
    {
        currentEmbers = 0;
        currentSecrets = 0;
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
                secretCollected = false;
            }
        }
        else if (!secretCollected)
        {
            timer = 2f;
        }
    }

    public void AddEmber(int embertoAdd)
    {
        currentEmbers += embertoAdd;
        emberText.text = "Embers: " + currentEmbers;
        SetCountText();
    }

    public void SetCountText()
    {
        emberText.text = "Embers: " + currentEmbers.ToString();
    }

    public void SetSecondCountText()
    {
        secretsText.text = "Secrets Found: " + currentSecrets.ToString();
    }

    public void AddSecret(int secrettoAdd)
    {
        secretCollected = true;
        currentSecrets += secrettoAdd;
        secretsText.text = "Secrets Found: " + currentSecrets;
        SetSecondCountText();
    }
}