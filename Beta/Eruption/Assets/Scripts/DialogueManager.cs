using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI nameDisplay;
    public GameObject[] buttonPrompts;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] characterName;
    public bool dialogueActive;
    public bool characterVicinity;
    public float typingSpeed;
    public bool endDialogue;
    public bool continueAllowed;
    public bool returnPressed;
    public bool spacePressed;

    public int xbox360Controller = 0;
    public int pS4Controller = 0;
    private int index;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        buttonPrompts[3].SetActive(false);
        //spacePressed = false;
        //If Index has less than the number of elements in the 'sentences' array by -1
        if (index < sentences.Length - 1)
        {
            index++;
            //Resets textDisplay so sentences don't stack
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
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
        if (characterVicinity)
        {
            dialogueActive = false;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                PlayerController.canMove = false;
                returnPressed = true;
                if (returnPressed)
                {
                    continueAllowed = false;
                    nameDisplay.enabled = true;
                    dialogueBox.SetActive(true);
                    StartCoroutine("Type");
                }
            }
            if (nameDisplay.enabled && dialogueBox.activeSelf)
            {
                dialogueActive = true;
            }
            if (textDisplay.text == sentences[index])
            {
                buttonPrompts[3].SetActive(true);
                continueAllowed = true;
                //Placing this 'if' statement here within the previous one will stop the button from being spammed.
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    spacePressed = true;
                    continueAllowed = false;
                    NextSentence();
                }
                else
                {
                    spacePressed = false;
                }
            }
        }
        /*if(sentences.Length > index)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                endDialogue = true;
                if (endDialogue)
                {
                    dialogueActive = false;
                    nameDisplay.enabled = false;
                    dialogueBox.SetActive(false);
                    characterVicinity = false;
                    continueAllowed = false;
                    PlayerController.canMove = true;
                }
            }
        }*/

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
