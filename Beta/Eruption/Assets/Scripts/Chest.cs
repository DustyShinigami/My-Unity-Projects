using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    BoxCollider m_Collider;
    float m_ScaleX, m_ScaleY, m_ScaleZ;

    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_ScaleX = 2.424546f;
        m_ScaleY = 1.28647f;
        m_ScaleZ = 3.120195f;
    }

    public void ChestCollider()
    {
        m_Collider.size = new Vector3(m_ScaleX, 0.25f, m_ScaleZ);
    }
}
