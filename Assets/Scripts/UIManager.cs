using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject loadingScreenPanel;

    void Start()
    {
        // Show the main menu panel and hide the loading screen panel when the game starts
        ShowMainMenu();
    }

    public void OnPlayButtonClick()
    {
        
        // Hide the main menu panel and show the loading screen panel
        HideMainMenu();
        ShowLoadingScreen();

        // Start the loading process (e.g., load assets, initialize game state)
        StartCoroutine(LoadGameSceneAfterDelay(10f));
    }

    public void OnExitButtonClick()
    {
        // Close the game
        Application.Quit();
    }

    // Coroutine to load the game scene after a delay
    IEnumerator LoadGameSceneAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Load the next scene or the scene you want to transition to
        SceneManager.LoadScene(1);
    }

    // Helper method to show the main menu panel
    void ShowMainMenu()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
    }

    // Helper method to hide the main menu panel
    void HideMainMenu()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);
    }

    // Helper method to show the loading screen panel
    void ShowLoadingScreen()
    {
        if (loadingScreenPanel != null)
            loadingScreenPanel.SetActive(true);
    }
}
