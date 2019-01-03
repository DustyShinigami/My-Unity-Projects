using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldReset : MonoBehaviour
{

    [HideInInspector] public GameObject[] goldBarArray;
    public GameObject goldBarPrefab;
    public Transform[] spawnPoints;

    private Vector3 startPosition;

    public void Start()
    {
        goldBarArray = GameObject.FindGameObjectsWithTag("Gold");
    }

    public void DestroyGold()
    {
        //Using '==', 'true' and 'false' in if statements can be replaced with just the variable for 'true' and '!' at the beginning for 'false'.
        if (!FindObjectOfType<Checkpoint>().checkpoint1On)
        {
            for (int i = 0; i < goldBarArray.Length; i++)
            {
                Transform sp = spawnPoints[i];
                Destroy(goldBarArray[i]);
                goldBarArray[i] = Instantiate(goldBarPrefab, sp.position, sp.rotation);
            }
        }
    }
}