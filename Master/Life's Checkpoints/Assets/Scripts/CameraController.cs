using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //A SerializeField will make a private variable appear in the Inspector, but it can't be accessed by other scripts.

    [SerializeField] GameObject player;
    [SerializeField] [Range(0.5f, 3f)] float followAhead = 2f;
    [SerializeField] [Range(0.5f, 3f)] float smoothing = 1f;

    //m_min and m_max applies to the Mathf function and avoids Magic Numbers. It's purpose is to work out the lower or higher of two values and not allow it to go any lower or higher.
    //Magic Numbers involve setting a value for something that could easily be changed at a later date. If this value is used in many different places, each one has to be changed and something else could be affected by accident. Therefore it's best to set the value as a variable and reference that variable. That way, if it does need to be changed, only one instance of it will need to be changed.
    //const, or Constants, can either be numbers, values, booleans, strings etc. that cannot be changed. Don't use one for something that may change over time.

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