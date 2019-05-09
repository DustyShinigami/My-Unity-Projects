using System.Collections;
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
    public bool interact;
    public float gravityScale;
    public float knockBackForce;
    public float knockBackTime;
    public float invincibilityLength;
    public Renderer playerRenderer;
    public Material textureChange;
    public Material textureDefault;
    public bool allowCombat = false;
    public bool allowJump;
    public bool allowInteract;

    private Vector3 moveDirection;
    private Vector3 extraDirections;
    private float knockBackCounter;
    private float invincibilityCounter;
    private CharacterController controller;

    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1"))
        {
            allowCombat = true;
            allowJump = true;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("start_area"))
        {
            allowCombat = false;
            allowJump = true;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
        {
            allowCombat = false;
            allowJump = false;
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
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
            {
                if (moveVertical > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0);
                }
                else if (moveVertical < 0)
                {
                    transform.eulerAngles = new Vector3(0, 180);
                }
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
                else
                {
                    allowJump = false;
                }

                if (allowCombat)
                {
                    if (Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 7"))
                    {
                        attack = true;
                        playerRenderer.material = textureChange;
                    }
                    else if (!Input.GetKey(KeyCode.Space) || !Input.GetKey("joystick button 7"))
                    {
                        attack = false;
                        playerRenderer.material = textureDefault;
                    }
                }
                else if (!allowCombat)
                {
                    attack = false;
                    playerRenderer.material = textureDefault;
                }

                if (allowInteract)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
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

        if (attack)
        {
            anim.SetTrigger("Attack");
        }
        if (interact)
        {
            anim.SetBool("keyPressed", controller.isGrounded);
        }
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }

    public void Pickup()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
        {
            if(gameObject.name == "Pickup Trigger")
            {
                interact = true;
            }
        }
    }
}