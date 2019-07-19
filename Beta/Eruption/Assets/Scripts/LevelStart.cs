using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    public static Vector3 respawnPoint;
    public static Quaternion startPosition;
    public PlayerController thePlayer
    {
        get
        {
            if (_thePlayer != null)
                return _thePlayer;

            _thePlayer = GameObject.FindWithTag("Player")?.GetComponentInChildren<PlayerController>();
            return _thePlayer;
        }
    }

    private PlayerController _thePlayer = null;

    public void Start()
    {
        respawnPoint = thePlayer.transform.position;
        startPosition = thePlayer.transform.rotation;
    }

    /*public void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;
        if (currentName == null)
        {
            currentName = "Replaced";
        }
    }*/
}
