using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpriteUp : MonoBehaviour
{
    public float MoveSpeed;

    void Update()
    {
        transform.position += transform.up * MoveSpeed * 0.5f * Time.deltaTime;
    }
}
