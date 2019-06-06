using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float lifeTime;

	void Update()
    {
        if(lifeTime <= 0)
        {
            Destroy(gameObject, lifeTime);
        }
	}
}
