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
    public bool allowInteract = false;
    public float gravityScale;
    public float knockBackForce;
    public float knockBackTime;
    //public Material textureChange;
    //public Material textureDefault;
    public bool allowCombat;
    public bool allowJump;
    public static bool canMove;
    public ChestTrigger chest
    {
        get
        {
            if (_chest != null)
                return _chest;

            _chest = GameObject.FindWithTag("Chest Trigger")?.GetComponent<ChestTrigger>();
            return _chest;
        }
    }

    private ChestTrigger _chest = null;
    private Vector2 moveDirection;
    private Vector2 moveHorizontal;
    private float knockBackCounter;
    private CharacterController controller;
    private Quaternion targetRot;
    private bool headingLeft = false;
    private Pickup pickupWeapon;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        ScreenFader.deactivatePlayer += DisablePlayer;
        ScreenFader.reactivatePlayer += EnablePlayer;
    }

    void OnDisable()
    {
        ScreenFader.deactivatePlayer -= DisablePlayer;
        ScreenFader.reactivatePlayer -= EnablePlayer;
    }

    void Start()
    {
        Cursor.visible = false;
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
        //To avoid any control or animation issues, each code block must be within this code block
        if (knockBackCounter <= 0 && canMove)
        {
            moveHorizontal.x = Input.GetAxis("Horizontal");
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
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 20f);

            //Adds character rotation when changing direction vertically
            /*if(moveVertical.y < 0f && lookingUp || (moveVertical.y > 0f && !lookingUp))
            {
                if (moveVertical.y > 0f) targetrot = Quaternion.Euler(0, 0, 0);
                if (moveVertical.y < 0f) targetrot = Quaternion.Euler(0, 180, 0);
                lookingUp = !lookingUp;
            }*/

            if (SceneManagement.insideHut && canMove)
            {
                float moveHorizontalSnap = Input.GetAxis("Horizontal");
                float moveVerticalSnap = Input.GetAxis("Vertical");

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
                else if (moveVerticalSnap > 0)
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
                    if (Input.GetKeyDown(KeyCode.KeypadPlus))
                    {
                        moveDirection.y = jumpForce;
                        jumped = true;
                    }
                    else if (!Input.GetKeyDown(KeyCode.KeypadPlus))
                    {
                        jumped = false;
                    }
                    if (SceneManagement.xbox360Controller == 1)
                    {
                        if (Input.GetKeyDown("joystick button 0"))
                        {
                            moveDirection.y = jumpForce;
                            jumped = true;
                        }
                        else if (!Input.GetKeyDown("joystick button 0"))
                        {
                            jumped = false;
                        }
                    }
                    else if (SceneManagement.ps4Controller == 1)
                    {
                        if (Input.GetKeyDown("joystick button 1"))
                        {
                            moveDirection.y = jumpForce;
                            jumped = true;
                        }
                        else if (!Input.GetKeyDown("joystick button 1"))
                        {
                            jumped = false;
                        }
                    }
                }
            }
            if (allowCombat)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("Attack");
                    //GameObject projectileObject = Instantiate(projectilePrefab);
                    //projectilePrefab.transform.position = spawnPoint.transform.position + spawnPoint.transform.forward;
                }
                else if (SceneManagement.xbox360Controller == 1)
                {
                    if (Input.GetKeyDown("joystick button 1"))
                    {
                        anim.SetTrigger("Attack");
                    }
                }
                else if (SceneManagement.ps4Controller == 1)
                {
                    if (Input.GetKeyDown("joystick button 2"))
                    {
                        anim.SetTrigger("Attack");
                    }
                }
            }
            if (allowInteract)
            {
                if (SceneManagement.xbox360Controller == 1)
                {
                    if (Input.GetKeyDown("joystick button 2"))
                    {
                        StartCoroutine("Pickup");
                    }
                }
                else if (SceneManagement.ps4Controller == 1)
                {
                    if (Input.GetKeyDown("joystick button 0"))
                    {
                        StartCoroutine("Pickup");
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        StartCoroutine("Pickup");
                    }
                }
            }
            if (ChestTrigger.allowOpen)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    StartCoroutine("Open");
                }
                else if (Input.GetKeyDown(KeyCode.Return) && !ChestTrigger.allowOpen)
                {
                    anim.SetBool("Interact", false);
                }
                else if (SceneManagement.xbox360Controller == 1)
                {
                    if (Input.GetKeyDown("joystick button 2"))
                    {
                        StartCoroutine("Open");
                    }
                    else if (Input.GetKeyDown("joystick button 2") && !ChestTrigger.allowOpen)
                    {
                        anim.SetBool("Interact", false);
                    }
                }
                else if (SceneManagement.ps4Controller == 1)
                {
                    if (Input.GetKeyDown("joystick button 0"))
                    {
                        StartCoroutine("Open");
                    }
                    else if (Input.GetKeyDown("joystick button 0") && !ChestTrigger.allowOpen)
                    {
                        anim.SetBool("Interact", false);
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
    }

    void DisablePlayer()
    {
        gameObject.SetActive(false);
    }

    void EnablePlayer()
    {
        gameObject.SetActive(true);
    }

    public IEnumerator Pickup()
    {
        canMove = false;
        anim.SetBool("Interact", controller.isGrounded);
        pickupWeapon.ObjectActivation();
        yield return new WaitForSeconds(1f);
        allowInteract = false;
        canMove = true;
    }

    public IEnumerator Open()
    {
        canMove = false;
        anim.SetBool("Interact", controller.isGrounded);
        chest.ChestOpen();
        yield return new WaitForSeconds(1.5f);
        canMove = true;
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}