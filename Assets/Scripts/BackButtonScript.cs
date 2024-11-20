using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    [Tooltip("Enter the name of the scene to load")]
    public string sceneToLoad; // Public variable to input the scene name

    public void OnBackButtonPressed()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Load the scene specified in the Inspector
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            // Provide a warning if the scene name is empty
            Debug.LogWarning("Scene name is empty. Please specify a scene in the Inspector.");
        }
    }
}
