using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretsPickup : MonoBehaviour
{
    public int value;
    public Animator secretAnim;

    void Awake()
    {
        secretAnim = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddSecret(value);
            Destroy(gameObject);
        }
    }

    IEnumerator SecretRevealed()
    {
        secretAnim.SetTrigger("secretMove");
        yield return new WaitForSeconds(2f);
        FindObjectOfType<GameManager>().AddSecret(value);
        Destroy(gameObject);
    }
}
