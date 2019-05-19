using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    public float gravityScale;
    public bool canMove;
    public static bool interact = false;
    public static bool allowInteract = false;
    public GameObject destinationTarget;
    public GameObject startPoint;
    public float targetDistance;
    public float allowedDistance = 5;
    public RaycastHit shot;

    private Vector3 moveDirection;
    private Vector3 extraDirections;
    private float walkCounter;
    private int WalkDirection;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = false;
        walkCounter = walkTime;
        //MoveDirection();
    }

    public void Update()
    {
        if (!canMove)
        {
            isWalking = false;
            anim.SetBool("isGrounded", controller.isGrounded);
            //If the character can't move, then the Speed is set to 0. Otherwise it'll use the horizontal input value.
            anim.SetFloat("Speed",
                !canMove
                ? 0f
                : Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector2(moveHorizontal * moveSpeed, moveDirection.y);
            extraDirections = new Vector2(moveVertical * moveSpeed, extraDirections.y);
            controller.Move(moveDirection * Time.deltaTime);

            if (moveHorizontal > 0)
            {
                transform.eulerAngles = new Vector2(0, 90);
            }
            else if (moveHorizontal < 0)
            {
                transform.eulerAngles = new Vector2(0, -90);
            }
            if (!InteractionController.charactersTalking)
            {
                isWalking = true;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
                {
                    targetDistance = shot.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        moveSpeed = 0.02f;
                        GetComponent<Animation>().Play("Walk");
                        transform.position = Vector3.MoveTowards(startPoint.transform.position, destinationTarget.transform.position, moveSpeed);
                    }
                    else
                    {
                        moveSpeed = 0;
                        GetComponent<Animation>().Play("Idle");
                    }
                }

                if (interact)
                {
                    anim.SetBool("Interact", controller.isGrounded);
                }
            }
        }
            /*if (isWalking)
            {
                walkCounter -= Time.deltaTime;
                if (walkCounter < 0)
                {
                    isWalking = false;
                }
                /*switch (WalkDirection)
                {
                    case 0:
                        controller.velocity = new Vector2(moveSpeed, 0);
                        break;

                    case 1:
                        myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                        break;
                }
            }

    public void MoveDirection()
    {
        WalkDirection = Random.Range(0, 1);
        isWalking = true;
        walkCounter = walkTime;
    }*/
    }
}