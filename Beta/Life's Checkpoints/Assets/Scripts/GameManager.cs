﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text goldText;
    public static int currentGold;
    //public bool textBlink = true;

    void Start()
    {
        //StartCoroutine("FlashText");
    }

    public void AddGold(int goldtoAdd)
    {
        currentGold = currentGold + 1;
        //Make sure to add the below method in the right place to call it. If it's only done in the Start function, this will only happen at the start and never again. If trying to access a method from another script, use the 'FindObjectOfType'.
        SetCountText();
    }

    public void SetCountText()
    {
        goldText.text = "Gold: " + currentGold.ToString();
        FindObjectOfType<Objectives>().Objective1();
    }

    /*public IEnumerator FlashText()
    {
        while (textBlink)
        {
            goldText.enabled = false;
            yield return new WaitForSeconds(.5f);
            goldText.enabled = true;
            yield return new WaitForSeconds(.5f);
        }
    }*/
}