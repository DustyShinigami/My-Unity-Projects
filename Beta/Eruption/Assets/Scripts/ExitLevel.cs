using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public string levelToLoad;

    private PlayerController thePlayer;

    void Start()
    {
        thePlayer = GetComponent<PlayerController>();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
