using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int currentGold;
    public Text goldText;

    public void AddGold(int goldtoAdd)
    {
        currentGold += goldtoAdd;
        goldText.text = "Gold: " + currentGold;
    }
}