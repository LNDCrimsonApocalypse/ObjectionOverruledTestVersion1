using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    private const string ScoreKey = "PlayerScore"; // Key to store the score in PlayerPrefs
    public Text scoreText; // Optional: Assign this only if you want to display the score in the current scene

    private void Start()
    {
        // If there's a scoreText assigned, update the display
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Adds points to the current score and saves it.
    /// </summary>
    /// <param name="points">The number of points to add.</param>
    public void AddToScore(int points)
    {
        int currentScore = GetScore();
        currentScore += points;
        PlayerPrefs.SetInt(ScoreKey, currentScore);
        PlayerPrefs.Save();
        Debug.Log($"Added {points} points. New score: {currentScore}");
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Retrieves the current score from PlayerPrefs.
    /// </summary>
    /// <returns>The current score.</returns>
    public int GetScore()
    {
        return PlayerPrefs.GetInt(ScoreKey, 0); // Default to 0 if no score is saved
    }

    /// <summary>
    /// Resets the score to zero.
    /// </summary>
    public void ResetScore()
    {
        PlayerPrefs.SetInt(ScoreKey, 0);
        PlayerPrefs.Save();
        Debug.Log("Score has been reset to zero.");
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Updates the score display in the UI.
    /// </summary>
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {GetScore()}";
        }
        else
        {
            Debug.Log("No score text assigned for this scene.");
        }
    }
}
