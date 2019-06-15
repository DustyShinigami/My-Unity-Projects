using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*[SerializeField] GameObject player = null;

    public BoxCollider boundBox;

    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;
    private PlayerController thePlayer;

    const float m_minY = 2f;
    Vector3 targetPosition;
    Vector3 cameraOffset;

    void Start()
    {
        theCamera = GetComponent<Camera>();
        thePlayer = GetComponent<PlayerController>();
        cameraOffset = transform.position - player.transform.position;
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {
        transform.position = player.transform.position + cameraOffset;
        targetPosition.y = Mathf.Min(targetPosition.y, m_minY);
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }*/
}