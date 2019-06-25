using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public float jumpForce;
    public bool jumped;
    public float gravityScale;
    public float knockBackForce;
    public float knockBackTime;
    public float invincibilityLength;

    private float jumpDelay;
    private Vector3 moveDirection;
    private float knockBackCounter;
    private float invincibilityCounter;
    private CharacterController controller;

    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        jumped = false;
        if(jumpDelay <= 0)
        {
            jumpDelay = 5;
        }
    }

    void Update()
    {
        if (knockBackCounter <= 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(moveHorizontal * moveSpeed, moveDirection.y);

            if (moveHorizontal > 0)
            {
                transform.eulerAngles = new Vector3(0, 90);
            }
            else if (moveHorizontal < 0)
            {
                transform.eulerAngles = new Vector3(0, -100);
            }

            if (controller.isGrounded)
            {
                moveDirection.y = -1f;
                if (Input.GetKey(KeyCode.KeypadPlus))
                {
                    moveDirection.y = jumpForce;
                    jumped = true;
                    StartCoroutine(SpamBlockco());
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));

    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }

    public IEnumerator SpamBlockco()
    {
        if (moveDirection.y == jumpForce)
        {
            yield return new WaitForSeconds(jumpDelay);
        }
        yield return null;
        jumped = false;
    }
}