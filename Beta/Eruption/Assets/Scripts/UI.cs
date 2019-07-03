using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance
    {
        get
        {
            return _instance;
        }
    }

    private static UI _instance;

    public static void Init()
    {
        if (_instance = null) SceneManager.LoadScene("level 1, room 1", LoadSceneMode.Additive);
    }

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
