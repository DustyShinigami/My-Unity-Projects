using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public float walkTime;
    public float gravityScale;
    public bool canMove;
    public static bool interact = false;
    public static bool allowInteract = false;
    public GameObject wayPoint;
    public bool isWalking;

    private Vector3 moveDirection;
    //private Vector3 extraDirections;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = false;
        //MoveDirection();
    }

    public void Walk()
    {
        canMove = true;
    }
        /*transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, wayPoint.transform.position) < 0.2f)
        {
            canMove = false;
            //yield return new WaitForSeconds(walkTime);
        }
    }*/

    public void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoint.transform.position) < 0.2f)
            {
                canMove = false;
                //yield return new WaitForSeconds(walkTime);
            }
        }
        /*if (!canMove)
        {
            isWalking = false;
            anim.SetBool("isGrounded", controller.isGrounded);
            //If the character can't move, then the Speed is set to 0. Otherwise it'll use the horizontal input value.
            anim.SetFloat("Speed",
                !canMove
                ? 0f
                : Mathf.Abs(Input.GetAxis("Horizontal")));
        }*/

        /*if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector2(moveHorizontal * moveSpeed, moveDirection.y);
            //extraDirections = new Vector2(moveVertical * moveSpeed, extraDirections.y);
            controller.Move(moveDirection * Time.deltaTime);

            if (moveHorizontal > 0)
            {
                transform.eulerAngles = new Vector2(0, 90);
            }
            else if (moveHorizontal < 0)
            {
                transform.eulerAngles = new Vector2(0, -90);
            }
            if (interact)
            {
                anim.SetBool("Interact", controller.isGrounded);
            }
        }*/
    }
}