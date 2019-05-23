using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public bool canMove;
    public static bool interact = false;
    public static bool allowInteract = false;
    public Transform target;
    public bool targetReached;

    private CharacterController controller;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        canMove = false;
        Idle();
    }

    public void Idle()
    {
        anim.SetBool("isMoving", false);
        if (anim.GetBool("isMoving") == false)
        {
            anim.SetTrigger("Idle");
        }
    }

    public void Walk()
    {
        canMove = true;
    }

    public void Update()
    {
        if (canMove)
        {
            transform.eulerAngles = new Vector2(0, 90);
            target.transform.position = new Vector3(-12.45f, 12.005f, -0.695f);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            anim.SetBool("isMoving", true);
            anim.ResetTrigger("Idle");
            anim.SetFloat("Speed", 0.2f);
            anim.SetTrigger("Walk");
            if (transform.position == target.position)
            {
                anim.SetFloat("Speed", 0f);
                anim.ResetTrigger("Walk");
                targetReached = true;
                if (targetReached)
                {
                    //anim.ResetTrigger("Walk");
                    Idle();
                    allowInteract = true;
                }
                /*allowInteract = true;
                if (targetReached && allowInteract)
                {
                    Idle();
                    interact = true;
                    //anim.SetTrigger("Interact");
                }*/
            }
        }
    }
}