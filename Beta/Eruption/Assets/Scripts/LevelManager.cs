using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool levelLoaded;

    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            levelLoaded = true;
            Debug.Log("Level loaded");
            //Level1();
            Debug.Log("Level 1 method called");
        }
    }
}
