using UnityEngine;
using UnityEngine.SceneManagement;

public class PageTransition : MonoBehaviour
{
    public Animator animator; // Reference to the Animator
    public string nextSceneName; // Name of the next page (scene)

    public void TriggerNextPage()
    {
        // Set the trigger to play the animation
        animator.SetTrigger("NextPage");
    }

    // This function is called at the end of the animation (via Animation Event)
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
