using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*public PlayerController thePlayer;
    public float reloadLength;

    private Vector3 respawnPoint;
    private bool playerReloading;

    void Start()
    {
        respawnPoint = thePlayer.transform.position;
        /*Player player = new Player();
        player.SetPosition(new Vector3(0, 0, 0));
        player.SetRotation(new Vector3(0, 0, 0));
        player.SetControl(true);
    }

    void Update()
    {

    }

    public void PlayerReload()
    {
        if (playerReloading)
        {
            StartCoroutine("ReloadingCo");
        }
    }

    public IEnumerator ReloadingCo()
    {
        Instantiate(thePlayer, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(reloadLength);
        playerReloading = false;
        thePlayer.transform.position = respawnPoint;
        Debug.Log("Player respawned");
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }*/
}
