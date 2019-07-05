using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    public Transform[] startPosition;
    public GameObject playerPrefab;
    public static LevelStart instance;

    private PlayerController thePlayer;

    void Start()
    {
        thePlayer = playerPrefab.GetComponent<PlayerController>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 1"))
        {
            thePlayer.transform.position = startPosition[0].position;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level 1, room 2"))
        {
            thePlayer.transform.position = startPosition[1].position;
        }
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
}
