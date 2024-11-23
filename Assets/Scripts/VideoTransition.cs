using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneTransition : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load

    private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component
        videoPlayer = GetComponent<VideoPlayer>();

        // Attach the event listener
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // This method is called when the video finishes
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
