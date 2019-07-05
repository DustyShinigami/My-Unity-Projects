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

    public static UI _instance;

    void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /*public static void Init()
    {
        Debug.Log("UI script called");
        if (_instance = null)SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }*/
}
