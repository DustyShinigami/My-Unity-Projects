using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    //Array (list) of all the back and foregrounds to be parallaxed
    public Transform[] backgrounds;
    //How smooth the parallax is going to be. Make sure to set this above 0
    public float smoothing = 1f;

    //The proportion of the camera's movement to move the backgrounds by
    private float[] parallaxScales;
    //Reference to the main camera's transform
    private Transform cam;
    //The position of the camera in the previous frame
    private Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        //The previous frame had the current frame's camera position
        previousCamPos = cam.position;
        //Assigning corresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        //A 'for' statement must inlude an initialisation, a condition, and steps. A variable must be initialised, the condition is a bool which will check if something is true or false, and the steps will increment or decrement the variable.
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        //for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //The parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //Set a target x position, which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //Create a target position, which is the background's current position with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //Fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //Set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
