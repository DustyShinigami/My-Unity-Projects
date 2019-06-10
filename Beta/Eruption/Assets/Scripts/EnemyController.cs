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
        moveLeft = true;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            if ((moveHorizontal.x < 0f && !moveLeft) || (moveHorizontal.x > 0f && moveLeft))
            {
                if (moveHorizontal.x < 0f) targetRot = Quaternion.Euler(0, 90, 0);
                if (moveHorizontal.x > 0f) targetRot = Quaternion.Euler(0, 270, 0);
                moveLeft = !moveLeft;
            }
        }
        if (moveLeft)
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else if (!moveLeft)
        {
            transform.eulerAngles = new Vector2(0, -90);
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
        }
        else if (transform.position == startPoint.position)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("Speed", 0f);
            transform.eulerAngles = new Vector2(0, -180);
            anim.SetTrigger("Idle");
        }
    }

    IEnumerator ReturnToStart()
    {
        yield return new WaitForSeconds(2.5f);
        PlayerController.canMove = true;
        moveLeft = true;
        anim.SetBool("isFloating", true);
        anim.SetFloat("Speed", 0.2f);
    }

    public void Idle()
    {
        anim.SetBool("isFloating", false);
        anim.SetFloat("Speed", 0f);
    }

    public void MoveRight()
    {
        moveLeft = false;
        //anim.ResetTrigger("Idle");
        anim.SetBool("isFloating", true);
        anim.SetFloat("Speed", 0.2f);
    }
}
