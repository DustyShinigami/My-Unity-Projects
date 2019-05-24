using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public bool moveRight;
    public bool interact;
    public Transform target;
    public Transform startPoint;

    private CharacterController controller;

    /*enum NPCState
    {
        moveRight,
        Idle,
        Interact
    }

    NPCState currentState = NPCState.Idle;*/

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        Idle();
    }

    /*public void NPCStates()
    {

        if (currentState == NPCState.moveRight)
        {
            anim.ResetTrigger("Idle");
            anim.SetBool("isMoving", true);
            anim.SetFloat("Speed", 0.2f);
            anim.SetTrigger("Walk");
        }
        else if (currentState == NPCState.Idle)
        {
            anim.ResetTrigger("Walk");
            anim.SetBool("isMoving", false);
            anim.SetFloat("Speed", 0f);
            anim.SetTrigger("Idle");
        }
        else if (currentState == NPCState.Interact)
        {
            anim.ResetTrigger("Walk");
            anim.SetBool("isMoving", false);
            anim.SetFloat("Speed", 0f);
            anim.SetTrigger("Interact");
        }
    }*/

    public void Idle()
    {
        anim.ResetTrigger("Interact");
        anim.SetBool("isWalking", false);
        anim.SetFloat("Speed", 0f);
        anim.SetTrigger("Idle");
    }

    public void MoveRight()
    {
        moveRight = true;
        anim.ResetTrigger("Idle");
        anim.SetBool("isWalking", true);
        anim.SetFloat("Speed", 0.2f);
    }

    public void Interact()
    {
        interact = true;
        anim.SetBool("isWalking", false);
        anim.SetFloat("Speed", 0f);
        anim.SetTrigger("Interact");
    }

    public void Update()
    {
        if (moveRight)
        {
            transform.eulerAngles = new Vector2(0, 90);
            target.transform.position = new Vector3(-12.45f, 12.005f, -0.695f);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        /*if (!moveRight)
        {
            transform.eulerAngles = new Vector2(0, -90);
            target.transform.position = new Vector3(-14.5f, 11.98f, -0.606f);
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
        }*/
        if (transform.position == target.position)
        {
            moveRight = false;
            Interact();
        }
        /*else if(transform.position == startPoint.position)
        {
            moveRight = false;
            transform.eulerAngles = new Vector2(0, -180);
        }*/
    }
}