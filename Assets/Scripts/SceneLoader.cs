using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject loaderUI;
    public Slider progressSlider;
    public float displayDuration = 2f; // How long the loader is visible

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnSceneLoad()
    {
        // Dynamically add a loading screen if it doesn't already exist
        GameObject loaderObject = new GameObject("SceneLoader");
        loaderObject.AddComponent<SceneLoader>();
        DontDestroyOnLoad(loaderObject); // Ensure it persists while the scene loads
    }

    private void Awake()
    {
        // Initialize the loader UI and slider dynamically or from the scene
        if (loaderUI == null)
        {
            loaderUI = new GameObject("LoaderUI");
            Canvas canvas = loaderUI.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            // Add a slider for progress
            GameObject sliderObject = new GameObject("ProgressSlider");
            sliderObject.transform.SetParent(loaderUI.transform);
            progressSlider = sliderObject.AddComponent<Slider>();
        }

        loaderUI.SetActive(false); // Hide initially
    }

    private void Start()
    {
        StartCoroutine(TrackSceneLoading());
    }

    private IEnumerator TrackSceneLoading()
    {
        loaderUI.SetActive(true);

        float progress = 0;
        while (progress < 1f)
        {
            // Simulate scene loading progress (replace with actual logic if needed)
            progress += Time.deltaTime / displayDuration;
            progressSlider.value = progress;

            yield return null;
        }

        loaderUI.SetActive(false); // Hide UI once the scene has loaded
        Destroy(gameObject); // Clean up the SceneLoader object
    }
}
