using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PageLoader : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject loaderUI; // UI to display the loader
    public Slider progressSlider; // Progress bar slider
    public float displayDuration = 2f; // How long the loader is visible

    private bool isLoading = false;

    private void Awake()
    {
        // Dynamically create the loader UI if it doesn't exist
        if (loaderUI == null)
        {
            loaderUI = new GameObject("LoaderUI");
            Canvas canvas = loaderUI.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            // Add background image
            GameObject background = new GameObject("Background");
            background.transform.SetParent(loaderUI.transform);
            Image bgImage = background.AddComponent<Image>();
            bgImage.color = new Color(0, 0, 0, 0.5f); // Semi-transparent black background
            RectTransform bgRect = background.GetComponent<RectTransform>();
            bgRect.anchorMin = Vector2.zero;
            bgRect.anchorMax = Vector2.one;
            bgRect.offsetMin = Vector2.zero;
            bgRect.offsetMax = Vector2.zero;

            // Add a slider for progress
            GameObject sliderObject = new GameObject("ProgressSlider");
            sliderObject.transform.SetParent(loaderUI.transform);
            progressSlider = sliderObject.AddComponent<Slider>();

            RectTransform sliderRect = sliderObject.GetComponent<RectTransform>();
            sliderRect.anchorMin = new Vector2(0.3f, 0.45f);
            sliderRect.anchorMax = new Vector2(0.7f, 0.55f);
            sliderRect.offsetMin = Vector2.zero;
            sliderRect.offsetMax = Vector2.zero;

            loaderUI.SetActive(false); // Hide initially
        }
    }

    /// <summary>
    /// Call this function to display the loader temporarily.
    /// </summary>
    public void ShowLoader()
    {
        if (!isLoading)
            StartCoroutine(ShowLoaderCoroutine());
    }

    private IEnumerator ShowLoaderCoroutine()
    {
        isLoading = true;
        loaderUI.SetActive(true);

        // Simulate progress
        float progress = 0;
        while (progress < 1f)
        {
            progress += Time.deltaTime / displayDuration;
            progressSlider.value = progress;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f); // Add a small delay to ensure visibility
        loaderUI.SetActive(false);
        isLoading = false;
    }
}
