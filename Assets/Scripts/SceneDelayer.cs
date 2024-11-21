using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneDelayer : MonoBehaviour
{
    public Image fadeImage; // Drag the Image from the Canvas here in the Inspector
    public float fadeDuration = 1.0f; // Duration for fading in/out
    public float waitBeforeFade = 1.0f; // Duration to display the white screen

    private void Start()
    {
        if (fadeImage == null)
        {
            Debug.LogError("Fade Image is not assigned.");
            return;
        }

        // Start the transition
        StartCoroutine(SceneDelayCoroutine());
    }

    private IEnumerator SceneDelayCoroutine()
    {
        // Set the image to fully opaque (white screen)
        fadeImage.color = new Color(1, 1, 1, 1);

        // Wait for a moment before fading
        yield return new WaitForSeconds(waitBeforeFade);

        // Fade out
        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        // Ensure the alpha is set to 0 and deactivate the GameObject
        fadeImage.color = new Color(1, 1, 1, 0);
        fadeImage.gameObject.SetActive(false);
    }
}
