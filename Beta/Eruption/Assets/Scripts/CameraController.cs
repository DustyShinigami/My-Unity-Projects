using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] [Range(0.1f, 2f)] float followAhead = 2f;
    [SerializeField] [Range(0.1f, 2f)] float smoothing = 1f;

    //public PlayerController playerController;

    //private Vector3 smoothedForward;

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
        //smoothedForward = Vector3.MoveTowards(smoothedForward, playerController.GetTravelDirection(), 0.5f * Time.deltaTime);
        //targetPosition = (player.transform.position + (smoothedForward * followAhead));
        targetPosition.y = Mathf.Min(targetPosition.y, m_minY);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}