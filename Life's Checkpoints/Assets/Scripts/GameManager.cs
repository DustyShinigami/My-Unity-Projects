using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text goldText;
    //public Text pCText;
    //public GameObject panel1;
    public static int currentGold;
    public float blinkSpeed = 2.0f;

    /*void Start()
    {
        goldText.color = Mathf.Round(Mathf.PingPong(Time.time * blinkSpeed, 1.0f));
        StartCoroutine("FlashText");
    }*/

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

    /*public void Panel1()
    {
        panel1.SetActive (true);
        pCText.text = "Gaming PC\n I've wanted a gaming PC for a number of years.";
    }*/
}