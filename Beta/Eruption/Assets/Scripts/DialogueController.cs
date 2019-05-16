using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public GameObject[] dialogueBoxes;

    private SceneManagement theSceneManager;
    //private NPC theNPC;

    public void Start()
    {
        theSceneManager = FindObjectOfType<SceneManagement>();
        //theNPC = FindObjectOfType<NPC>();
    }

    /*public void Dialogue()
    {
        if (NPC.charactersTalking)
        {
            dialogueBoxes[0].SetActive(true);
            if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return))
            {
                dialogueBoxes[0].SetActive(false);
                dialogueBoxes[1].SetActive(true);
                if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return))
                {
                    dialogueBoxes[1].SetActive(false);
                }
            }
        }
    }*/
}
