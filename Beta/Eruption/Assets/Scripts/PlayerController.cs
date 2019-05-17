﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public float jumpForce;
    public bool jumped;
    public bool attack;
    public static bool interact = false;
    public static bool allowInteract = false;
    public float gravityScale;
    public float knockBackForce;
    public float knockBackTime;
    public float invincibilityLength;
    public Renderer playerRenderer;
    public Material textureChange;
    public Material textureDefault;
    public bool allowCombat;
    public bool allowJump;
    public bool notDestroyed;

    private Vector3 moveDirection;
    private Vector3 extraDirections;
    private float knockBackCounter;
    private float invincibilityCounter;
    private CharacterController controller;

    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area"))
        {
            allowCombat = false;
            allowJump = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
        {
            allowCombat = false;
            allowJump = false;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area 2"))
        {
            allowCombat = false;
            allowJump = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1"))
        {
            allowCombat = true;
            allowJump = true;
        }
    }

    void Update()
    {
        if (knockBackCounter <= 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(moveHorizontal * moveSpeed, moveDirection.y);
            extraDirections = new Vector3(moveVertical * moveSpeed, extraDirections.y);

            if (moveHorizontal > 0)
            {
                transform.eulerAngles = new Vector3(0, 90);
            }
            else if (moveHorizontal < 0)
            {
                transform.eulerAngles = new Vector3(0, -90);
            }
            //To possibly prevent diagonal movement with some control setups, try adding 'else if'
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
            {
                if (moveVertical > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0);
                }
                //Use this to make the character face towards the camera.
                /*else if (moveVertical < 0)
                {
                    transform.eulerAngles = new Vector3(0, 180);
                }*/
            }
            if (controller.isGrounded)
            {
                if (allowJump)
                {
                    moveDirection.y = -1f;
                    //GetKeyDown will require the player to press the button each time they want to jump. GetKey will allow the player to spam the jump button if they keep pressing it down.
                    if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown("joystick button 1"))
                    {
                        moveDirection.y = jumpForce;
                        jumped = true;
                    }
                    else if (!Input.GetKeyDown(KeyCode.KeypadPlus) || !Input.GetKeyDown("joystick button 1"))
                    {
                        jumped = false;
                    }
                }

                if (allowCombat)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 7"))
                    {
                        attack = true;
                        anim.SetTrigger("Attack");
                        playerRenderer.material = textureChange;
                    }
                    if (!attack)
                    {
                        if (!Input.GetKeyDown(KeyCode.Space) || !Input.GetKeyDown("joystick button 7"))
                        {
                            attack = false;
                            playerRenderer.material = textureDefault;
                        }
                    }
                }

                if (allowInteract)
                {
                    if (SceneManagement.xbox360Controller == 1)
                    {
                        if (Input.GetKeyDown("joystick button 2"))
                        {
                            interact = true;
                        }
                    }
                    else if (SceneManagement.ps4Controller == 1)
                    {
                        if (Input.GetKeyDown("joystick button 0"))
                        {
                            interact = true;
                        }
                    }
                    else
                    {
                        interact = true;
                    }
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
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (interact)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                anim.SetBool("Interact", controller.isGrounded);
                FindObjectOfType<Pickup>().ObjectActivation();
                interact = false;
                allowInteract = false;
            }
        }
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}