using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public int currentEmbers;
    public TextMeshProUGUI emberText;

    public void AddEmber(int embertoAdd)
    {
        currentEmbers += embertoAdd;
        emberText.text = "Embers: " + currentEmbers;
    }
}