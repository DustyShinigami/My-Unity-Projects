using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public float gravityScale;
    public bool canMove;
    public static bool interact = false;
    public static bool allowInteract = false;
    public Transform[] target;

    private CharacterController controller;
    private Vector3 moveDirection;
    private int current;

    void Start()
    {
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
            if (transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, moveSpeed * Time.deltaTime);
                controller.Move(moveDirection * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 90);
                anim.SetBool("isGrounded", controller.isGrounded);
                anim.SetFloat("Speed", moveSpeed);
            }
            else current = (current + 1) % target.Length;
        }
    }
}