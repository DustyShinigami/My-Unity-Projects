using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Player
{
    void Start()
    {
        Player player = new Player();
        player.SetPosition(new Vector3(0, 0, 0));
        player.SetRotation(new Vector3(0, 0, 0));
        player.SetControl(true);
    }

    void Update()
    {

    }
}
