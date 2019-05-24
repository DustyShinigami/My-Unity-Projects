using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public bool moveRight;
    //public bool isMoving;
    public bool interact;
    public bool leverActivated;
    public Transform target;
    public Transform startPoint;
    //public NPCState currentState;

    private CharacterController controller;

    /*public enum NPCState
    {
        MovingLeft,
        MovingRight,
        Idle,
        Interact
    }*/

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        //currentState = NPCState.Idle;
        Idle();
    }

    /*public void MoveRight()
    {
        isMoving = true;
        if (isMoving)
        {
            if (currentState == NPCState.MovingRight)
            {
                anim.ResetTrigger("Idle");
                anim.SetBool("isMoving", true);
                anim.SetFloat("Speed", 0.2f);
                anim.SetTrigger("Walk");
            }
        }
    }*/

    /*public void NPCStates()
    {
        if (currentState == NPCState.MovingRight)
        {
            anim.ResetTrigger("Idle");
            anim.SetBool("isMoving", true);
            anim.SetFloat("Speed", 0.2f);
            anim.SetTrigger("Walk");
        }
        else if (currentState == NPCState.MovingLeft)
        {
            anim.ResetTrigger("Idle");
            anim.SetBool("isMoving", true);
            anim.SetFloat("Speed", 0.2f);
            anim.SetTrigger("Walk");
            transform.eulerAngles = new Vector2(0, -90);
            startPoint.transform.position = new Vector3(-14.5f, 11.98f, -0.606f);
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
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

    /*public void Update()
    {
        switch (currentState)
        {
            case NPCState.MovingRight:
                transform.eulerAngles = new Vector2(0, 90);
                target.transform.position = new Vector3(-12.45f, 12.005f, -0.695f);
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                break;
        }
        {
            transform.eulerAngles = new Vector2(0, 90);
            target.transform.position = new Vector3(-12.45f, 12.005f, -0.695f);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }*/

    IEnumerator ReturnToStart()
    {
        yield return new WaitForSeconds(3f);
        anim.ResetTrigger("Interact");
        leverActivated = true;
        interact = false;
        PlayerController.canMove = true;
        anim.SetBool("isWalking", true);
        anim.SetFloat("Speed", 0.2f);

    }
    
    public void Idle()
    {
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
        StartCoroutine("ReturnToStart");
    }

    public void Update()
    {
        if (moveRight)
        {
            transform.eulerAngles = new Vector2(0, 90);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else if (leverActivated)
        {
            transform.eulerAngles = new Vector2(0, -90);
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
        }
        if (transform.position == target.position)
        {
            moveRight = false;
            Interact();
        }
        else if (transform.position == startPoint.position)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("Speed", 0f);
            transform.eulerAngles = new Vector2(0, -180);
            anim.SetTrigger("Idle");
        }
    }
}