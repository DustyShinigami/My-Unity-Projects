using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public SceneManagement theSceneManager;
    public bool characterVicinity;

    private bool insideHut;

    void Start()
    {
        theSceneManager = FindObjectOfType<SceneManagement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (insideHut)
        {
            if (other.gameObject.name == "Player")
            {
                characterVicinity = true;
                //To call methods from other scripts, the GetComponent function must be used along with a reference name (theSceneManager)
                theSceneManager.ControllerDetection();
                //When accessing variables from other scripts, they must use a static and the name of the script it's featured in must be used (SceneManagement)
                if (characterVicinity && SceneManagement.ps4Controller == 1)
                {
                    theSceneManager.PS4Prompts();
                }
                else if (characterVicinity && SceneManagement.xbox360Controller == 1)
                {
                    theSceneManager.Xbox360Prompts();
                }
                else
                {
                    theSceneManager.PCPrompts();
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        characterVicinity = false;
    }

    void Update()
    {
        if (characterVicinity)
        {
            if(SceneManagement.xbox360Controller == 1)
            {
                if (Input.GetKeyDown("joystick button 2"))
                {

                }
            }
        }
        else if(SceneManagement.ps4Controller == 1)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("characters are talking");
            }
        }
    }
}
