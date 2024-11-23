using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BackButtonScript : MonoBehaviour
{
    // Static stack to track scene history
    private static Stack<string> sceneHistory = new Stack<string>();

    // Custom scene name for navigation
    [Tooltip("Set a custom scene to navigate to when this button is clicked (optional).")]
    public string customSceneName = "";

    private void Start()
    {
        // Add the current scene to the history stack (if not already the top scene)
        string currentScene = SceneManager.GetActiveScene().name;
        if (sceneHistory.Count == 0 || sceneHistory.Peek() != currentScene)
        {
            sceneHistory.Push(currentScene);
        }
    }

    public void OnBackButtonPressed()
    {
        if (!string.IsNullOrEmpty(customSceneName))
        {
            // Navigate to the custom scene if specified
            SceneManager.LoadScene(customSceneName);
        }
        else if (sceneHistory.Count > 1)
        {
            // Otherwise, go back to the previous scene
            sceneHistory.Pop(); // Remove the current scene
            string previousScene = sceneHistory.Peek();
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("No previous scene to return to, and no custom scene specified.");
        }
    }

    public static void AddSceneToHistory(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            sceneHistory.Push(sceneName);
        }
    }

    public void SetCustomScene(string sceneName)
    {
        // Allow event listeners or other scripts to set a custom scene dynamically
        customSceneName = sceneName;
    }
}
