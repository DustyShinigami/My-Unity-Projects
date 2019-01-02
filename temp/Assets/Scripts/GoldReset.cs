using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldReset : MonoBehaviour {

    [HideInInspector]public GameObject[] goldBarArray;
    public GameObject goldBarPrefab;
    public GameObject goldBarPrefabClone;

    private Vector3 startPosition;

    public void Start()
    {
        goldBarArray = GameObject.FindGameObjectsWithTag("Gold");
        startPosition = goldBarPrefabClone.transform.position;
    }

    public void DestroyGold()
    {
        //Using '==', 'true' and 'false' in if statements can be replaced with just the variable for 'true' and '!' at the beginning for 'false'.
        if (!FindObjectOfType<Checkpoint>().checkpoint1On)
        {
            foreach (GameObject Gold in goldBarArray)
            {
                {
                    Destroy(Gold);
                    //Debug.Log("Gold Destroyed");
                    ResetGold();
                }
            }
        }

    }

    public void ResetGold()
    {
        goldBarPrefabClone = Instantiate(goldBarPrefab, startPosition, Quaternion.identity) as GameObject;
    }
}
