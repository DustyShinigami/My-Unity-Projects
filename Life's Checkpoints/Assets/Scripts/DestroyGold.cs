using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGold : MonoBehaviour
{

    public GameObject[] goldBar;
    public Checkpoint checkpoint;

    void Start()
    {
        //To destroy multiple objects at once, use an Array. Then use 'GameObject.FindGameObjectsWithTag'.
        goldBar = GameObject.FindGameObjectsWithTag("Gold");
        //To reference a method from another script in a public function, an object reference must be used. In this case, 'checkpoint'.
        //Reference a method from another script using GetComponent.
        checkpoint = GetComponent<Checkpoint>();
    }

    /*public void GoldDestroy()
    {
        //For Statics, an object reference isn't necessary. Use the FindObjectOfType to find the appropriate script and reference the Type, such as HealthManager.
        if (checkpoint.checkpoint1On == false)
        {
            foreach (GameObject Gold in goldBar)
            {
                Destroy(Gold);
            }
        }

    }*/
}
