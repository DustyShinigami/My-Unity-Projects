using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //public Transform thePlayer;
    public Animator anim;
    public float moveSpeed;
    public float rotSpeed;
    public bool moveLeft;
    public bool canMove;
    public Transform target;
    public Transform startPoint;
    public int maxHealth;
    public float currentHealth = 30;
    public float invincibilityLength;
    public Renderer enemyRenderer;
    public float flashLength;

    private float invincibilityCounter;
    private float flashCounter;

    void Start()
    {
        //thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        canMove = true;
        anim = GetComponent<Animator>();
        currentHealth += maxHealth;
    }

    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                enemyRenderer.enabled = !enemyRenderer.enabled;
                flashCounter = flashLength;
            }
            if (invincibilityCounter <= 0)
            {
                enemyRenderer.enabled = true;
            }
        }
        if (canMove)
        {
            if (moveLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 270f, 0f), rotSpeed * Time.deltaTime);
            }
            else if (!moveLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), rotSpeed * Time.deltaTime);
            }
            if (transform.position == target.position)
            {
                anim.SetBool("isFloating", true);
                anim.SetFloat("Speed", 0.2f);
                moveLeft = true;
            }
            else if (transform.position == startPoint.position)
            {
                anim.SetBool("isFloating", true);
                anim.SetFloat("Speed", 0.2f);
                moveLeft = false;
            }
        }
    }
    public void Damage(float amount)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                invincibilityCounter = invincibilityLength;
                enemyRenderer.enabled = false;
                flashCounter = flashLength;
            }
        }
    }
}
