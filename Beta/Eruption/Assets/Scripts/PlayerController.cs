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
    public static bool canMove;

    private Vector2 moveDirection;
    private Vector2 moveHorizontal;
    private Vector2 moveVertical;
    private float knockBackCounter;
    private float invincibilityCounter;
    private CharacterController controller;
    private Quaternion targetRot;
    private bool headingLeft = false;
    private Pickup pickupWeapon;

    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        pickupWeapon = FindObjectOfType<Pickup>();
        canMove = true;
        targetRot = transform.rotation;
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
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 1"))
        {
            allowCombat = true;
            allowJump = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 2"))
        {
            allowCombat = true;
            allowJump = true;
        }
    }

    void Update()
    {
        if (knockBackCounter <= 0 && canMove)
        {
            moveHorizontal.x = Input.GetAxis("Horizontal");
            float moveHorizontalSnap = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            //moveVertical.y = Input.GetAxis("Vertical");
            moveDirection = new Vector2(moveHorizontal.x * moveSpeed, moveDirection.y);
            controller.Move(moveDirection * Time.deltaTime);

            //Adds character rotation when changing direction horizontally
            if ((moveHorizontal.x < 0f && !headingLeft) || (moveHorizontal.x > 0f && headingLeft))
            {
                if (moveHorizontal.x < 0f) targetRot = Quaternion.Euler(0, 270, 0);
                if (moveHorizontal.x > 0f) targetRot = Quaternion.Euler(0, 90, 0);
                headingLeft = !headingLeft;
            }

            //Adds character rotation when changing direction vertically
            /*if(moveVertical.y < 0f && lookingUp || (moveVertical.y > 0f && !lookingUp))
            {
                if (moveVertical.y > 0f) targetrot = Quaternion.Euler(0, 0, 0);
                if (moveVertical.y < 0f) targetrot = Quaternion.Euler(0, 180, 0);
                lookingUp = !lookingUp;
            }*/

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 20f);

            if (SceneManagement.insideHut)
            {
                //Adds character rotation when changing direction horizontally, but snaps instead of fully rotating
                if (moveHorizontalSnap > 0)
                {
                    transform.eulerAngles = new Vector2(0, 90);
                }
                else if (moveHorizontalSnap < 0)
                {
                    transform.eulerAngles = new Vector2(0, -90);
                }
                //To possibly prevent diagonal movement with some control setups, try adding 'else if'
                //Adds character rotation when changing direction vertically, but snaps instead of fully rotating
                else if (moveVertical > 0)
                {
                    transform.eulerAngles = new Vector2(0, 0);
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
                    if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown("joystick button 0"))
                    {
                        moveDirection.y = jumpForce;
                        jumped = true;
                    }
                    else if (!Input.GetKeyDown(KeyCode.KeypadPlus) || !Input.GetKeyDown("joystick button 0"))
                    {
                        jumped = false;
                    }
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
                    if (SceneManagement.xbox360Controller == 1)
                    {
                        if (Input.GetKeyDown("joystick button 2"))
                        {
                            //interact = true;
                            anim.SetBool("Interact", controller.isGrounded);
                            pickupWeapon.ObjectActivation();
                            interact = false;
                            allowInteract = false;
                        }
                    }
                    else if (SceneManagement.ps4Controller == 1)
                    {
                        if (Input.GetKeyDown("joystick button 0"))
                        {
                            //interact = true;
                            anim.SetBool("Interact", controller.isGrounded);
                            pickupWeapon.ObjectActivation();
                            interact = false;
                            allowInteract = false;
                        }
                    }
                    else
                    {
                        interact = true;
                        if (Input.GetKeyDown(KeyCode.Return))
                        {
                            anim.SetBool("Interact", controller.isGrounded);
                            pickupWeapon.ObjectActivation();
                            interact = false;
                            allowInteract = false;
                        }
                    }
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        anim.SetBool("isGrounded", controller.isGrounded);
        //If the character can't move, then the Speed is set to 0. Otherwise it'll use the horizontal input value.
        anim.SetFloat("Speed",
            !canMove
            ? 0f
            : Mathf.Abs(Input.GetAxis("Horizontal")));

        //anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        /*if (interact)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                anim.SetBool("Interact", controller.isGrounded);
                FindObjectOfType<Pickup>().ObjectActivation();
                interact = false;
                allowInteract = false;
            }
        }*/
        if (attack)
        {
            anim.SetTrigger("Attack");
            //Instantiate(projectileEffect, transform.position, transform.rotation);
        }
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}