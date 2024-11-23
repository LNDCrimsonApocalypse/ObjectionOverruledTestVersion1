using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class VideoSceneTransition : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load
    public float delayBeforeVideo = 2f; // Delay in seconds before the video starts

    private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component
        videoPlayer = GetComponent<VideoPlayer>();

        // Disable the VideoPlayer initially
        videoPlayer.playOnAwake = false;

        // Start the coroutine to delay the video start
        StartCoroutine(DelayedVideoStart());
    }

    // Coroutine to handle the delay before starting the video
    private IEnumerator DelayedVideoStart()
    {
        yield return new WaitForSeconds(delayBeforeVideo);

        // Play the video after the delay
        videoPlayer.Play();

        // Attach the event listener for when the video ends
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // This method is called when the video finishes
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
