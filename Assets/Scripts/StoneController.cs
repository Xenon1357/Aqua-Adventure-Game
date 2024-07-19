using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    private float speed;
    private bool hasPassedCameraBoundary = false;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        // Move the stone based on speed
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the stone has passed through the camera boundary
        if (!hasPassedCameraBoundary && transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            hasPassedCameraBoundary = true;
        }

        // Check if the stone is below the camera view and has passed the boundary
        if (hasPassedCameraBoundary && transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            Destroy(gameObject); // Destroy the stone when it's below the camera view and has passed the boundary
        }
    }
}