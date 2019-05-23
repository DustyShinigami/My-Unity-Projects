using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public bool moveRight;
    public bool moveLeft;
    public bool nPCMoving;
    public bool nPCIdle;
    public bool interact = false;
    public Transform target;
    public Transform startPoint;

    private CharacterController controller;
    private bool leverPulled;
    //private bool playerIdle;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        moveRight = false;
        moveLeft = false;
        nPCIdle = true;
        Idle();
    }

    public void Idle()
    {
        if (nPCIdle)
        {
            anim.ResetTrigger("Walk");
            anim.SetBool("isMoving", false);
            anim.SetFloat("Speed", 0f);
            anim.SetTrigger("Idle");
        }
    }

    public void Walk()
    {
        moveRight = true;
        if (moveRight)
        {
            if (nPCMoving)
            {
                anim.ResetTrigger("Idle");
                anim.SetBool("isMoving", true);
                anim.SetFloat("Speed", 0.2f);
                anim.SetTrigger("Walk");
            }
        }
        if (moveLeft)
        {
            if (nPCMoving)
            {
                anim.ResetTrigger("Idle");
                anim.SetBool("isMoving", true);
                anim.SetFloat("Speed", 0.2f);
                anim.SetTrigger("Walk");
            }
        }
    }

    public void Interact()
    {
        if (interact)
        {
            anim.ResetTrigger("Walk");
            anim.SetBool("isMoving", false);
            anim.SetFloat("Speed", 0f);
            anim.SetTrigger("Interact");
        }
    }

    public void Update()
    {
        if (moveRight)
        {
            transform.eulerAngles = new Vector2(0, 90);
            target.transform.position = new Vector3(-12.45f, 12.005f, -0.695f);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            nPCMoving = true;
            if (nPCMoving)
            {
                nPCIdle = false;
                Walk();
            }
        }
        if (transform.position == target.position)
        {
            moveRight = false;
            nPCMoving = false;
            interact = true;
            if (interact)
            {
                Interact();
            }
        }
        if (leverPulled)
        {
            nPCMoving = true;
            moveLeft = true;
            if (nPCMoving && moveLeft)
            {
                Walk();
            }
        }
        if (moveLeft)
        {
            transform.eulerAngles = new Vector2(0, -90);
            startPoint.transform.position = new Vector3(-14.5f, 11.98f, -0.606f);
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
        }
        if (transform.position == startPoint.position)
        {
            moveLeft = true;
            nPCMoving = false;
            transform.eulerAngles = new Vector2(0, -180);
        }
    }
}