using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Retrieve the score from the parameter passed by the BoatMovement script
        float currentScore = PlayerPrefs.GetFloat("CurrentScore", 0f);

        // Display the score on the UI Text component
        scoreText.text = "Score: " + Mathf.RoundToInt(currentScore);
    }
    public void OnHomeButtonCLick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRetryClick()
    {
        SceneManager.LoadScene(1);
    }
}
