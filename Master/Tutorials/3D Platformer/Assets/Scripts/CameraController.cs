using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public bool useOffsetValues;
    public Vector3 offset;
    public float rotateSpeed;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY;

    void Start()
    {
        //Allows the user to change how close/far the camera is from the player
        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        //Makaes pivot position equal to the player's position
        pivot.transform.position = target.transform.position;
        //Makes pivot its own object, ie: not a child of an object. In the Project window, keep pivot a child object of the camera for future levels
        pivot.transform.parent = null;


        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        //Makes the pivot move with the player
        pivot.transform.position = target.transform.position;

        //Get the X position of the mouse and rotate the pivot
        float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        //Get the Y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        //Add an invert option for the camera
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limit up/down camera rotation
        //Quaternion and Euler Angles must be used for rotations when moving the camera with the mouse
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360 + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360 + minViewAngle, 0, 0);
        }

        //Move the camera based on the current rotation of the pivot and the original offset of the camera
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }

        transform.LookAt(target);
    }
}