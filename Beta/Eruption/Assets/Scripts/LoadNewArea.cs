using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    private PlayerController thePlayer;
    private ScreenFader theScreenFader;
    private SceneManagement theSceneManager;
    private bool nextArea;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theScreenFader = FindObjectOfType<ScreenFader>();
        theSceneManager = FindObjectOfType<SceneManagement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            nextArea = true;
            StartCoroutine("NextArea");
        }
    }

    IEnumerator NextArea()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area 2"))
        {
            thePlayer.gameObject.SetActive(false);
            SceneManager.LoadScene("level 1, room 1");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 1"))
        {
            //UI.MakeSingleton();
            thePlayer.gameObject.SetActive(false);
            theScreenFader.StartCoroutine("ScreenFade");
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("level 1, room 2");
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 2"))
        {
            //UI.MakeSingleton();
            thePlayer.gameObject.SetActive(false);
            theScreenFader.StartCoroutine("ScreenFade");
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Credits");
        }
    }
}
