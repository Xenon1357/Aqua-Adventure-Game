using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BoatMovement : MonoBehaviour
{
    public float boatSpeed = 2f;
    public Button leftButton;
    public Button rightButton;
    public TextMeshProUGUI scoreText; // Change to TextMeshProUGUI

    private bool moveLeft;
    private bool moveRight;
    private float score = 0f;

    void Start()
    {
        // Add the OnClick listeners to the buttons
       if (leftButton != null)

        {
            leftButton.onClick.AddListener(MoveLeft);
        }

        if (rightButton != null)
        {
            rightButton.onClick.AddListener(MoveRight);
        }
        
        }

    void Update()
    {
        MoveBoat();

        // Update and display the score
        score += Time.deltaTime * boatSpeed;
        scoreText.text = "Score: " + Mathf.RoundToInt(score);
    }

    void MoveBoat()
    {
        float horizontalInput = 0f;
        float verticalInput = -1f; // Move the boat downwards by default

        if (moveLeft)
        {
            horizontalInput = 1f;
        }
        else if (moveRight)
        {
            horizontalInput = -1f;
        }

        // Move the boat based on input
        Vector3 movement = new Vector3(horizontalInput * boatSpeed * Time.deltaTime, verticalInput * boatSpeed * Time.deltaTime, 0f);
        transform.Translate(movement);

        // Restrict the boat's movement within camera boundaries
        float screenWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize * 2f;
        float boatXPosition = Mathf.Clamp(transform.position.x, -screenWidth / 2f, screenWidth / 2f);
        float boatYPosition = Mathf.Clamp(transform.position.y, -screenHeight / 2f, screenHeight / 2f);
        transform.position = new Vector3(boatXPosition, boatYPosition, transform.position.z);

        // Reset flags when no button is pressed
        if (!moveLeft && !moveRight)
        {
            moveLeft = false;
            moveRight = false;
        }
    }

    void MoveLeft()
    {
        moveLeft = true;
        moveRight = false;
    }

    void MoveRight()
    {
        moveLeft = false;
        moveRight = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Boat collided with an obstacle!");

            // Add any additional logic or actions you want here
            PlayerPrefs.SetFloat("CurrentScore", score);

            // Change the scene (replace "YourNextSceneName" with the actual name of your next scene)
            SceneManager.LoadScene(2);
        }
    }
}
