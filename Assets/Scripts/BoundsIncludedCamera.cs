using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBounds : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1f,10f)]
    public float smoothFactor;
    public Vector3 minValues, maxValue;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        //define min xyz values and max xyz values
        Vector3 targetPosition = target.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValue.z));


        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition,smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
