using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;
    public GameObject playerModel;
    public float knockBackForce;
    public float knockBackTime;
    public float invincibilityLength;

    private Vector3 moveDirection;
    private float knockBackCounter;
    private float invincibilityCounter;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (knockBackCounter <= 0)
        {
            float yScale = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            //Normalised will help with allowing the player to move and turn in/from diagonal directions more smoothly
            moveDirection = moveDirection.normalized * speed;
            moveDirection.y = yScale;

            if (controller.isGrounded)
            {
                moveDirection.y = -1f;
                if (Input.GetKey(KeyCode.KeypadPlus))
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        //If this line isn't added or is disabled, the character will keep jumping on the spot. This makes the player 'grounded' and will enable the idle animation.
        controller.Move(moveDirection * Time.deltaTime);

        //Move the player in different directions based on camera look direction
        if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            //Stops the player from 'snapping' to a new direction
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        //Mathf.Abs gives an absolute value of something. What is negative becomes positive and what is positive stays positive. Pressing forward would make the value 1, pressing back would make it -1. Mathf.Abs would chop off whether it's a + or - number and just make it a positive number when pressing and holding the movement keys.
        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}
