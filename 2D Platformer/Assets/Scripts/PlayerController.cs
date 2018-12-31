using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public Vector3 respawnPosition;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPosition = transform.position;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
        //Stops the player character from sliding when they stop.
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        //If the jump key is pressed and the player is grounded, they jump. If they're not grounded, the jump key can't be pressed. This stops the player from being able to keep jumping.
        if (Input.GetKey(KeyCode.KeypadPlus) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Mathf.Abs (Abs is short for Absolute) makes a minus number into a whole number - eg: -5 to 5
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillPlane")
        {
            transform.position = respawnPosition;
        }
        if(other.tag == "Checkpoint")
        {
            respawnPosition = transform.position;
        }
    }
}
