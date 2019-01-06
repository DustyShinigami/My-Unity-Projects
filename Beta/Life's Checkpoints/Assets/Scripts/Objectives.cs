using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour {

    public Text objective1;
    public Text checkpoint1Unlock;
    //public Text checkpointPrompt;
    public Text panelPrompt;

    void Start()
    {
        checkpoint1Unlock.enabled = false;
        objective1.text = "Collect 5 Gold Bars";
        Invoke("Hide", 3f);
        //checkpointPrompt.enabled = false;
    }

    public void Objective1()
    {
        if (GameManager.currentGold >= 5)
        {
            checkpoint1Unlock.enabled = true;
            checkpoint1Unlock.text = "Checkpoint Unlocked";
            Invoke("Hide", 3f);
            //ObjectiveComplete();
        }
    }

    /*public void ObjectiveComplete()
    {
        checkpointPrompt.enabled = true;
        checkpointPrompt.text = "Press Return to activate";
    }*/

    void Hide()
    {
        objective1.enabled = false;
        checkpoint1Unlock.enabled = false;
    }
}
