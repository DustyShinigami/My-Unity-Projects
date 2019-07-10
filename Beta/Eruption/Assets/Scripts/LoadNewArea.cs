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
    //private Vector3 destination = new Vector3(-14.78f, -0.184f, -1.115f);

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
            StartCoroutine("ExitArea");
        }
    }

    IEnumerator ExitArea()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area 2"))
        {
            thePlayer.gameObject.SetActive(false);
            SceneManager.LoadScene("level 1, room 1");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 1"))
        {
            thePlayer.gameObject.SetActive(false);
            theScreenFader.StartCoroutine("ScreenFade");
            yield return new WaitForSeconds(2f);
            //thePlayer.transform.position = destination;
            //thePlayer.gameObject.SetActive(true);
            SceneManager.LoadScene("level 1, room 2");
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 2"))
        {
            thePlayer.gameObject.SetActive(false);
            theScreenFader.StartCoroutine("ScreenFade");
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Credits");
        }
    }
}
