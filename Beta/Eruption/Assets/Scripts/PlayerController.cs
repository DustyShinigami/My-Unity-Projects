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
    public bool allowCombat = false;
    public bool allowJump;
    public string startPoint;

    private Vector3 moveDirection;
    private Vector3 extraDirections;
    private float knockBackCounter;
    private float invincibilityCounter;
    private CharacterController controller;
    private static bool playerExists;

    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        //Every bool starts on false
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
            //To possibly prevent diagonal movement with some control setups, try adding 'else if'
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hut_interior"))
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
                else if (!allowInteract)
                {
                    interact = false;
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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                anim.SetBool("Interact", controller.isGrounded);
                FindObjectOfType<Pickup>().ObjectActivation();
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