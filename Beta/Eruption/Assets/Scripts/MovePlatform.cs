using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    //Use this code to move a platform without using an animator.

    public GameObject objectToMove;
    public Transform startPosition;
    public Transform endPosition;
    public float moveSpeed;

    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = endPosition.position;
    }

    void Update()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (objectToMove.transform.position == endPosition.transform.position)
        {
            currentTarget = startPosition.transform.position;
        }
        if (objectToMove.transform.position == startPosition.transform.position)
        {
            currentTarget = endPosition.transform.position;
        }
    }

    //Adds a visual aid by showing the start and end positions as a green and red wire mesh.
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startPosition.position, objectToMove.transform.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endPosition.position, objectToMove.transform.localScale);

    }*/
}
