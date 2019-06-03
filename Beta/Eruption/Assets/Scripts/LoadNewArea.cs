using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    //public Transform newStartPoint;

    private PlayerController thePlayer;
    private ScreenFader theScreenFader;
    private SceneManagement theSceneManager;
    public bool nextArea;
    //private CameraController theCamera;
    //private bool playerMoved;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theScreenFader = FindObjectOfType<ScreenFader>();
        theSceneManager = FindObjectOfType<SceneManagement>();
        //theCamera = FindObjectOfType<CameraController>();
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
            theScreenFader.StartCoroutine("ScreenFade");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("level 1, room 1");
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 1"))
        {
            thePlayer.gameObject.SetActive(false);
            theScreenFader.StartCoroutine("ScreenFade");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("level 1, room 2");
        }
        //thePlayer.transform.position = newStartPoint.position;
        //playerMoved = true;
        //thePlayer.gameObject.SetActive(true);
    }

    /*void Update()
    {
        if (playerMoved)
        {
            theCamera.transform.position = new Vector3(14.4f, theCamera.transform.position.y, theCamera.transform.position.z);
        }
    }*/
}
