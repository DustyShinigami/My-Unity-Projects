using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public bool nextArea;
    public Transform newStartPoint;

    private PlayerController thePlayer;
    private ScreenFader theScreenFader;
    private CameraController theCamera;
    private bool playerMoved;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theScreenFader = FindObjectOfType<ScreenFader>();
        theCamera = FindObjectOfType<CameraController>();
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
        thePlayer.gameObject.SetActive(false);
        theScreenFader.StartCoroutine("ScreenFade");
        yield return new WaitForSeconds(3f);
        thePlayer.transform.position = newStartPoint.position;
        playerMoved = true;
        thePlayer.gameObject.SetActive(true);
        //theCamera.transform.position = new Vector3(14.4f, theCamera.transform.position.y, theCamera.transform.position.z);
    }

    void Update()
    {
        if (playerMoved)
        {
            theCamera.transform.position = new Vector3(14.4f, theCamera.transform.position.y, theCamera.transform.position.z);
        }
    }
}
