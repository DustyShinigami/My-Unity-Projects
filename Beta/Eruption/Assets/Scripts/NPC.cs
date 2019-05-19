using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public float moveSpeed;
    public bool isWalking;
    public float walkTime;

    private float walkCounter;
    private Rigidbody2D myRigidbody;
    private int WalkDirection;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        walkCounter = walkTime;
        MoveDirection();
    }

    public void Update()
    {
        if (InteractionController.charactersTalking)
        {
            isWalking = true;
        }
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            if(walkCounter < 0)
            {
                isWalking = false;
            }

            /*switch (WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    break;

                case 1:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }*/
        }
    }

    public void MoveDirection()
    {
        WalkDirection = Random.Range(0, 1);
        isWalking = true;
        walkCounter = walkTime;
    }
}