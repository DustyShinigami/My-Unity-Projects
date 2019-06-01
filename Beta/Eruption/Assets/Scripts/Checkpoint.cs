using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite unlitCandle;
    public Sprite litCandle;

    private SpriteRenderer theSpriteRenderer;
    private bool checkpointActive;

    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            theSpriteRenderer.sprite = litCandle;
            checkpointActive = true;
        }
    }
}
