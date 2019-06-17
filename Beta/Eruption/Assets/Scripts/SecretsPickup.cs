using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretsPickup : MonoBehaviour
{
    public int value;

    private Animator secretAnim;

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

    public void Secret()
    {
        StartCoroutine("SecretRevealed");
    }

    public IEnumerator SecretRevealed()
    {
        yield return new WaitForSeconds(.5f);
        secretAnim.SetTrigger("secretMove");
    }
}
