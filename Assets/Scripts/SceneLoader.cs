using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject loaderUI;
    public Slider progressSlider;

    private void Start()
    {
        // Ensure the loading UI is hidden initially
        if (loaderUI != null)
            loaderUI.SetActive(false);
    }

    /// <summary>
    /// Load a scene by index.
    /// </summary>
    /// <param name="index">Build index of the target scene.</param>
    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneCoroutine(index, null));
    }

    /// <summary>
    /// Load a scene by name.
    /// </summary>
    /// <param name="sceneName">Name of the target scene.</param>
    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(-1, sceneName));
    }

    /// <summary>
    /// Coroutine to load a scene asynchronously.
    /// </summary>
    /// <param name="sceneIndex">Build index of the target scene (-1 if using sceneName).</param>
    /// <param name="sceneName">Name of the target scene (null if using sceneIndex).</param>
    private IEnumerator LoadSceneCoroutine(int sceneIndex, string sceneName)
    {
        // Ensure the loading UI is active
        if (loaderUI != null)
            loaderUI.SetActive(true);

        // Initialize slider value
        if (progressSlider != null)
            progressSlider.value = 0;

        // Start loading the scene asynchronously
        AsyncOperation asyncOperation = sceneIndex >= 0
            ? SceneManager.LoadSceneAsync(sceneIndex)
            : SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = false;

        float progress = 0;

        // Monitor the loading progress
        while (!asyncOperation.isDone)
        {
            // Smoothly increase progress value
            progress = Mathf.Lerp(progress, asyncOperation.progress, Time.deltaTime * 5f);

            // Clamp the slider value to avoid abrupt jumps
            if (progressSlider != null)
                progressSlider.value = Mathf.Clamp01(progress / 0.9f);

            // Check if loading is nearly complete
            if (progress >= 0.9f)
            {
                if (progressSlider != null)
                    progressSlider.value = 1;

                // Allow the scene to activate
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }

        // Hide the loading UI after the scene is loaded
        if (loaderUI != null)
            loaderUI.SetActive(false);
    }
}
