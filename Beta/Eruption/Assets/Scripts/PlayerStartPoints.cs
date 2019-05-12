using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoints : MonoBehaviour
{
    //public Vector3 startDirection;
    public string pointName;

    private PlayerController thePlayer;
    private CameraController theCamera;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        //The player(controller's) startPoint, which has been accessed and the variable found on Start, checks to see if it's equal to or matches the pointName, which is found on each Start Point object through this script. If it does match, the player's transform/position will match the Start Point's. If it doesn't match, the player will be placed in the default location, such as at the beginning of the start_area scene. The pointName for a building's entrance/exit in one scene must match those in another scene for this to work! Think of them as teleporter links.
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
        }

        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(theCamera.transform.position.x, theCamera.transform.position.y, transform.transform.position.z);
    }
}
