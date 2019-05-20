using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //public GameObject[] dialogueBoxes;
    public GameObject[] buttonPrompts;
    //public Text dialogueText;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public bool dialogueActive;
    public bool characterVicinity;
    public float typingSpeed;

    public int xbox360Controller = 0;
    public int pS4Controller = 0;
    private int Index;

    public void Start()
    {

    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[Index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            dialogueActive = true;
            PlayerController.canMove = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            characterVicinity = true;
            ControllerDetection();
            if (pS4Controller == 1)
            {
                PS4Prompts();
            }
            else if (xbox360Controller == 1)
            {
                Xbox360Prompts();
            }
            else
            {
                PCPrompts();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        characterVicinity = false;
    }

    public void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            buttonPrompts[0].SetActive(false);
            //dialogueBoxes[0].SetActive(false);
            //dialogueActive = false;
            //PlayerController.canMove = true;
            //currentLine++;
        }

        /*if (currentLine >= dialogueLines.Length)
        {
            currentLine = 0;
        }*/

        //dialogueText.text = dialogueLines[currentLine];

        if (xbox360Controller == 1)
        {
            if (Input.GetKeyDown("joystick button 2"))
            {
                dialogueActive = true;
                PlayerController.canMove = false;
            }
        }
        else if (pS4Controller == 1)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                dialogueActive = true;
                PlayerController.canMove = false;
            }
        }
    }

    /*public void DialogueBoxes(string dialogue)
    {
        dialogueActive = true;
        dialogueBoxes[0].SetActive(true);
        dialogueBoxes[0] = dialogue;
        if (dialogueBoxes[0].activeSelf)
        {
            buttonPrompts[0].SetActive(false);
        }
    }*/

    public void Timer()
    {
        buttonPrompts[3].SetActive(true);
    }

    public void Hide()
    {
        buttonPrompts[0].SetActive(false);
        buttonPrompts[1].SetActive(false);
        buttonPrompts[2].SetActive(false);
    }

    public void Xbox360Prompts()
    {
        buttonPrompts[1].SetActive(true);
        Invoke("Hide", 3f);
    }

    public void PS4Prompts()
    {
        buttonPrompts[2].SetActive(true);
        Invoke("Hide", 3f);
    }

    public void PCPrompts()
    {
        buttonPrompts[0].SetActive(true);
        Invoke("Hide", 3f);
        /*if (dialogueActive)
        {
            //Turn off the button prompt completely whilst the player is talking
            buttonPrompts[0].SetActive(false);
            if (dialogueBoxes[0].activeSelf)
            {
                //Timer until a button prompt appears to skip to the next dialogue box
                Invoke("Timer", 3f);
            }
        }*/
    }

    public void ControllerDetection()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            //print(names[x].Length);
            if (names[x].Length == 19)
            {
                //print("PS4 CONTROLLER IS CONNECTED");
                pS4Controller = 1;
                xbox360Controller = 0;
                if (pS4Controller == 1)
                {
                    //Debug.Log("PS4 controller detected");
                }
            }
            else if (names[x].Length == 33)
            {
                //print("XBOX 360 CONTROLLER IS CONNECTED");
                pS4Controller = 0;
                xbox360Controller = 1;
                if (xbox360Controller == 1)
                {
                    //Debug.Log("Xbox 360 controller detected");
                }
            }
            else
            {
                pS4Controller = 0;
                xbox360Controller = 0;
            }

            if (xbox360Controller == 0 && pS4Controller == 0)
            {
                //Debug.Log("No controllers detected");
            }
        }
    }
}
