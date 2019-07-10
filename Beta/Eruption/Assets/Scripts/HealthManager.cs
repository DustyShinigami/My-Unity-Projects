using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    //The counters will count down and will keep counting down based on the length variables
    public int maxHealth;
    public int currentHealth;
    public float invincibilityLength;
    public float flashLength;
    public float respawnLength;
    public GameObject deathEffect;
    public Image blackScreen;
    public float fadeSpeed;
    public float waitForFade;
    public Image flame1;
    public Image flame2;
    public Image flame3;
    public Sprite fullFlame;
    //public Sprite threeQuarterFlame;
    public Sprite halfFlame;
    //public Sprite quarterFlame;
    public Sprite EmptyFlame;
    public PlayerController thePlayer;
    public GameManager theGameManager;

    //This checks to see if there's a renderer on the player and if not, it finds and gets it
    public SkinnedMeshRenderer playerRenderer
    {
        get
        {
            if (_playerRenderer != null)
                return _playerRenderer;

            _playerRenderer = GameObject.FindWithTag("Player")?.GetComponentInChildren<SkinnedMeshRenderer>();
            Debug.Assert(playerRenderer != null);
            return _playerRenderer;
        }
    }

    private float invincibilityCounter;
    private float flashCounter;
    private bool isRespawning;
    private Vector3 respawnPoint;
    private bool isFadetoBlack;
    private bool isFadefromBlack;
    private Quaternion startPosition;
    private SkinnedMeshRenderer _playerRenderer = null;

    void Start()
    {
        currentHealth = maxHealth;
        respawnPoint = thePlayer.transform.position;
        startPosition = thePlayer.transform.rotation;
        deathEffect.transform.position = thePlayer.transform.position;
    }

    void Update()
    {
        //These functions are checked every frame until the player takes damage
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            //The Flash Counter is currently set at 0.1 and will be within the 0 region as it counts down. During this period, the playerRenderer will alternate between on and off
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                //The Flash Counter will keep counting down and reloop depending on the Flash Length time
                flashCounter = flashLength;
            }
            //This makes sure after the flashing and invincibility has worn off that the player renderer is always turned back on so you can see the player
            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
        if (isFadetoBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadetoBlack = false;
            }
        }
        if (isFadefromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadefromBlack = false;
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        //If the invincibility countdown reaches zero it stops, making you no longer invincible and prone to taking damage again
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            FlameMetre();
            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                thePlayer.Knockback(direction);
                invincibilityCounter = invincibilityLength;
                playerRenderer.enabled = false;
                flashCounter = flashLength;
            }
        }
    }

    public void Respawn()
    {
        //A StartCoroutine must be set up before the IEnumerator can begin
        if (!isRespawning)
        {

            StartCoroutine("RespawnCo");
        }
    }

    //IEnumerators or Coroutines will execute the code separately at specified times while the rest of the code in a codeblock will carry on executing as normal
    public IEnumerator RespawnCo()
    {
        if (!Checkpoint.checkpointActive)
        {
            isRespawning = true;
            thePlayer.gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(respawnLength);
            isFadetoBlack = true;
            yield return new WaitForSeconds(waitForFade);
            isFadefromBlack = true;
            isRespawning = false;
            thePlayer.gameObject.SetActive(true);
            currentHealth = maxHealth;
            invincibilityCounter = invincibilityLength;
            playerRenderer.enabled = false;
            flashCounter = flashLength;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            FlameMetre();
            GameManager.currentEmbers = 0;
            theGameManager.SetCountText();
        }

        else if (Checkpoint.checkpointActive)
        {
            isRespawning = true;
            thePlayer.gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(respawnLength);
            isFadetoBlack = true;
            yield return new WaitForSeconds(waitForFade);
            isFadefromBlack = true;
            isRespawning = false;
            thePlayer.gameObject.SetActive(true);
            thePlayer.transform.position = respawnPoint;
            thePlayer.transform.rotation = startPosition;
            currentHealth = maxHealth;
            FlameMetre();
            invincibilityCounter = invincibilityLength;
            playerRenderer.enabled = false;
            flashCounter = flashLength;
        }
    }

    public void FlameMetre()
    {
        switch (currentHealth)
        {
            case 30:
                flame1.sprite = fullFlame;
                flame2.sprite = fullFlame;
                flame3.sprite = fullFlame;
                return;
            case 25:
                flame1.sprite = fullFlame;
                flame2.sprite = fullFlame;
                flame3.sprite = halfFlame;
                return;
            case 20:
                flame1.sprite = fullFlame;
                flame2.sprite = fullFlame;
                flame3.sprite = EmptyFlame;
                return;
            case 15:
                flame1.sprite = fullFlame;
                flame2.sprite = halfFlame;
                flame3.sprite = EmptyFlame;
                return;
            case 10:
                flame1.sprite = fullFlame;
                flame2.sprite = EmptyFlame;
                flame3.sprite = EmptyFlame;
                return;
            case 5:
                flame1.sprite = halfFlame;
                flame2.sprite = EmptyFlame;
                flame3.sprite = EmptyFlame;
                return;
            case 0:
                flame1.sprite = EmptyFlame;
                flame2.sprite = EmptyFlame;
                flame3.sprite = EmptyFlame;
                return;

            default:
                flame1.sprite = EmptyFlame;
                flame2.sprite = EmptyFlame;
                flame3.sprite = EmptyFlame;
                return;
        }
    }

    /*public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }*/

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}