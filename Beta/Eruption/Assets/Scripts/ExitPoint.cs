using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraController theCamera;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.transform.position = transform.position;
        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
    }

    void Update()
    {
        
    }
}
