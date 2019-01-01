using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGold : MonoBehaviour
{
    public GameObject[] goldBar;
    public GameObject goldBarPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        //To destroy multiple objects at once, use an Array. Then use 'GameObject.FindGameObjectsWithTag'.
        goldBar = GameObject.FindGameObjectsWithTag("Gold");
        //To reference a method from another script in a public function, an object reference must be used. In this case, 'checkpoint'.
        //GetComponent is considered more efficient than FindObjectOfType, but the latter avoids any errors saying an object reference hasn't been set.
    }

    public void ResetGold()
    {
        //For Statics, an object reference isn't necessary. Use the FindObjectOfType to find the appropriate script and reference the Type, such as HealthManager.
        if (!FindObjectOfType<Checkpoint>().checkpoint1On)
        {
            int spawnPointCounter = 0;
            foreach (GameObject Gold in goldBar)
            {
                {
                    Destroy(Gold);
                    Transform currentSP = spawnPoints[spawnPointCounter];
                    Instantiate(goldBarPrefab, currentSP.position, currentSP.rotation);
                    spawnPointCounter++;
                }
            }
        }

    }
}
