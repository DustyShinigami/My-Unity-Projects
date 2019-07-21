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

    void Update()
    {
        if (PauseMenu.restarted)
        {
            DestroyThis();
        }
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

}
