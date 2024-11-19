using UnityEngine;

public class AutoPageTransition : MonoBehaviour
{
    [Header("Page Transition Settings")]
    public float transitionDelay = 5f; // Delay (in seconds) before switching to the next page

    [Header("Page Settings")]
    public GameObject currentPage;    // Reference to the current page (Page 1)
    public GameObject nextPage;       // Reference to the next page (Page 2)
    public DialogueAnimation dialogueAnimation; // Reference to the DialogueAnimation script (Page 2)

    public string dialogueForNextPage; // The dialogue text for Page 2

    private void OnEnable()
    {
        // Start the transition process when the current page becomes active
        if (currentPage.activeSelf)
        {
            Invoke(nameof(SwitchToNextPage), transitionDelay);
        }
    }

    private void SwitchToNextPage()
    {
        // Hide the current page
        currentPage.SetActive(false);

        // Show the next page
        nextPage.SetActive(true);

        // Set the dialogue for the next page and start the typing effect
        if (dialogueAnimation != null)
        {
            dialogueAnimation.SetDialogue(dialogueForNextPage);
            dialogueAnimation.StartTyping(); // Start the typing effect
        }
    }
}
