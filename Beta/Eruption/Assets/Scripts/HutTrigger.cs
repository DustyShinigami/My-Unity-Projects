using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HutTrigger : MonoBehaviour
{
    public static bool hutLoaded;
    public GameObject buttonPrompt1;
    public bool enteranceVicinity;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enteranceVicinity = true;
            buttonPrompt1.SetActive (true);
            Invoke("Hide", 3f);
        }
    }

    public void Update()
    {
        if (enteranceVicinity)
        {
            if (Input.GetKeyDown("joystick button 2"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                hutLoaded = true;
            }
        }
    }

    public void Hide()
    {
        buttonPrompt1.SetActive (false);
    }
}