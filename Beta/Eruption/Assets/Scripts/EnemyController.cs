using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public float rotSpeed;
    public bool moveLeft;
    public bool canMove;
    public Transform target;
    public Transform startPoint;

    private Transform thePlayer;
    //private CharacterController controller;

    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        canMove = true;
        anim = GetComponent<Animator>();
        //controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            if (moveLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 270f, 0f), rotSpeed * Time.deltaTime);
            }
            else if (!moveLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), rotSpeed * Time.deltaTime);
            }
            if (transform.position == target.position)
            {
                anim.SetBool("isFloating", true);
                anim.SetFloat("Speed", 0.2f);
                moveLeft = true;
            }
            else if (transform.position == startPoint.position)
            {
                anim.SetBool("isFloating", true);
                anim.SetFloat("Speed", 0.2f);
                moveLeft = false;
            }
        }
    }
}
