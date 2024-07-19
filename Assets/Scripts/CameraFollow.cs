using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the boat's transform
    public float cameraFollowSpeed = 2f; // Adjust the camera follow speed as needed

    private float initialYOffset;

    void Start()
    {
        // Calculate the initial Y offset between the boat and the camera
        if (target != null)
        {
            initialYOffset = transform.position.y - target.position.y;
        }
    }

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        // Move the camera to follow the boat only on the Y-axis
        if (target != null)
        {
            float targetYPosition = target.position.y + initialYOffset;
            Vector3 targetPosition = new Vector3(transform.position.x, targetYPosition, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
        }
    }
}