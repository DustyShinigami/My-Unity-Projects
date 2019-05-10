using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    private bool isControlled;

    public void SetControl(bool value)
    {
        isControlled = value;
    }

    public void SetPosition(Vector3 position)
    {
        player.transform.position = position;
    }

    public void SetRotation(Vector3 eulerAngles)
    {
        player.transform.eulerAngles = eulerAngles;
    }
}
