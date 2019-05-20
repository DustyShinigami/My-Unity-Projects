using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] dialogue;

    private DialogueManager theDialogueManager;

    void Start()
    {
        theDialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            theDialogueManager.characterVicinity = true;
            theDialogueManager.ControllerDetection();
            if(Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return))
            {
                theDialogueManager.DialogueBoxes(dialogue[0]);
            }
            /*if (theDialogueManager.ps4Controller == 1)
            {
                theDialogueManager.PS4Prompts();
            }
            else if (theDialogueManager.xbox360Controller == 1)
            {
                theDialogueManager.Xbox360Prompts();
            }
            else
            {
                theDialogueManager.PCPrompts();
            }*/
        }
    }

    /*public void OnTriggerExit(Collider other)
    {
        theDialogueManager.characterVicinity = false;
    }*/
}
