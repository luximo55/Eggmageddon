using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset;
    public float y, z;
    private float smoothTime = 0.20f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    private void Start()
    {
        offset = new Vector3(0f, y, z);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
