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
    public float typingSpeed;

    private int xbox360Controller = 0;
    private int pS4Controller = 0;
    private int index;
    private BoxCollider dialogueTrigger;
    private int currentLine;
    private bool interactPressed;
    private bool continuePressed;
    private bool endDialogue;
    private bool continueAllowed;
    public bool characterVicinity;
    private bool dialogueActive;
    private NPC theNPC;

    void Start()
    {
        dialogueTrigger = GetComponent<BoxCollider>();
        theNPC = FindObjectOfType<NPC>();
    }

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
        buttonPrompts[4].SetActive(false);
        buttonPrompts[5].SetActive(false);
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
            //Set conditions to prevent button spamming. The Return key will only work if the dialogue box isn't active. If it is, it won't do anything.
            if (Input.GetKeyUp(KeyCode.Return) && !dialogueBox.activeSelf)
            {
                PlayerController.canMove = false;
                interactPressed = true;
                if (interactPressed)
                {
                    continueAllowed = false;
                    nameDisplay.enabled = true;
                    dialogueBox.SetActive(true);
                    StartCoroutine("Type");
                }
            }
            else if (SceneManagement.xbox360Controller == 1)
            {
                if (Input.GetKeyUp("joystick button 2") && !dialogueBox.activeSelf)
                {
                    PlayerController.canMove = false;
                    interactPressed = true;
                    if (interactPressed)
                    {
                        continueAllowed = false;
                        nameDisplay.enabled = true;
                        dialogueBox.SetActive(true);
                        StartCoroutine("Type");
                    }
                }
            }
            else if (SceneManagement.ps4Controller == 1)
            {
                if (Input.GetKeyUp("joystick button 0") && !dialogueBox.activeSelf)
                {
                    PlayerController.canMove = false;
                    interactPressed = true;
                    if (interactPressed)
                    {
                        continueAllowed = false;
                        nameDisplay.enabled = true;
                        dialogueBox.SetActive(true);
                        StartCoroutine("Type");
                    }
                }
            }
        }
        if (nameDisplay.enabled && dialogueBox.activeSelf)
        {
            dialogueActive = true;
            if (SceneManagement.xbox360Controller == 1)
            {
                if (buttonPrompts[4].activeSelf && Input.GetKeyUp("joystick button 2"))
                {
                    currentLine++;
                    if (currentLine >= sentences.Length)
                    {
                        nameDisplay.enabled = false;
                        dialogueBox.SetActive(false);
                        dialogueActive = false;
                        endDialogue = true;
                        characterVicinity = false;
                        dialogueTrigger.enabled = false;
                        theNPC.MoveRight();
                    }
                }
            }
            else if (SceneManagement.ps4Controller == 1)
            {
                if (buttonPrompts[5].activeSelf && Input.GetKeyUp("joystick button 0"))
                {
                    currentLine++;
                    if (currentLine >= sentences.Length)
                    {
                        nameDisplay.enabled = false;
                        dialogueBox.SetActive(false);
                        dialogueActive = false;
                        endDialogue = true;
                        characterVicinity = false;
                        dialogueTrigger.enabled = false;
                        theNPC.MoveRight();
                    }
                }
            }
            else
            {
                //The button prompt must be active in conjunction with the Space bar being pressed before the next line will show.
                if (buttonPrompts[3].activeSelf && Input.GetKeyUp(KeyCode.Space))
                {
                    currentLine++;
                    if (currentLine >= sentences.Length)
                    {
                        nameDisplay.enabled = false;
                        dialogueBox.SetActive(false);
                        dialogueActive = false;
                        endDialogue = true;
                        characterVicinity = false;
                        dialogueTrigger.enabled = false;
                        theNPC.MoveRight();
                    }
                }
            }
        }
        if (textDisplay.text == sentences[index] && SceneManagement.xbox360Controller == 1)
        {
            buttonPrompts[4].SetActive(true);
            continueAllowed = true;
            if (Input.GetKeyUp("joystick button 2"))
            {
                continuePressed = true;
                continueAllowed = false;
                NextSentence();
            }
            else
            {
                continuePressed = false;
            }
        }
        else if (textDisplay.text == sentences[index] && SceneManagement.ps4Controller == 1)
        {
            buttonPrompts[5].SetActive(true);
            continueAllowed = true;
            if (Input.GetKeyUp("joystick button 0"))
            {
                continuePressed = true;
                continueAllowed = false;
                NextSentence();
            }
            else
            {
                continuePressed = false;
            }
        }
        else if(textDisplay.text == sentences[index])
        {
            buttonPrompts[3].SetActive(true);
            continueAllowed = true;
            //Placing this 'if' statement here within the previous one will stop the button from being spammed.
            if (Input.GetKeyUp(KeyCode.Space))
            {
                continuePressed = true;
                continueAllowed = false;
                NextSentence();
            }
            else
            {
                continuePressed = false;
            }
        }
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
