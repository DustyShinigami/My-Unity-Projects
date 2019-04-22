using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] [Range(0.1f, 3f)] float followAhead = 2f;
    [SerializeField] [Range(0.1f, 3f)] float smoothing = 1f;

    const float m_minY = 2f;
    Vector3 targetPosition;
    Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    private void Update()
    {
        targetPosition = (player.transform.position + (player.transform.forward * followAhead)) + cameraOffset;
        targetPosition.y = Mathf.Min(targetPosition.y, m_minY);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}