using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public GameObject objectToMove;
    public Transform startPosition;
    public Transform endPosition;
    public float moveSpeed;

    private Vector2 currentTarget;

    //The platform needs to move from start to end on Play.
    void Start()
    {
        currentTarget = endPosition.position;
    }

    void Update()
    {
        //Whether Vector 2 or 3, a MoveTowards requires a current position, a target position and a float
        //Movement speeds must be multiplied by Time.deltaTime
        objectToMove.transform.position = Vector2.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
        if(objectToMove.transform.position == endPosition.position)
        {
            currentTarget = startPosition.position;
        }
        if(objectToMove.transform.position == startPosition.position)
        {
            currentTarget = endPosition.position;
        }
    }
}
