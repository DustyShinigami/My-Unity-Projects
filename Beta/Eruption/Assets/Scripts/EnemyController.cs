using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public bool moveLeft;
    public bool canMove;
    public Transform target;
    public Transform startPoint;

    private Transform thePlayer;
    private Vector2 moveHorizontal;
    private Quaternion targetRot;
    private CharacterController controller;

    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        canMove = true;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            if ((moveHorizontal.x < 0f && moveLeft) || (moveHorizontal.x > 0f && !moveLeft))
            {
                if (moveHorizontal.x < 0f) targetRot = Quaternion.Euler(0, 270, 0);
                if (moveHorizontal.x > 0f) targetRot = Quaternion.Euler(0, 90, 0);
                moveLeft = !moveLeft;
            }
        }
        if (moveLeft)
        {
            transform.eulerAngles = new Vector2(0, 270);
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
        }
        else if (!moveLeft)
        {
            transform.eulerAngles = new Vector2(0, 90);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        if (transform.position == target.position)
        {
            transform.eulerAngles = new Vector2(0, 90);
            anim.SetBool("isFloating", true);
            anim.SetFloat("Speed", 0.2f);
            moveLeft = true;
        }
        else if(transform.position == startPoint.position)
        {
            transform.eulerAngles = new Vector2(0, 270);
            anim.SetBool("isFloating", true);
            anim.SetFloat("Speed", 0.2f);
            moveLeft = false;
        }
    }
}
