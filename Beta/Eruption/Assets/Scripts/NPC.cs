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
            anim.Play("Walk");
            if (transform.position == target.position)
            {
                targetReached = true;
                if (targetReached)
                {
                    allowInteract = true;
                    anim.SetBool("Interact", controller.isGrounded);
                }
            }
        }
    }
}