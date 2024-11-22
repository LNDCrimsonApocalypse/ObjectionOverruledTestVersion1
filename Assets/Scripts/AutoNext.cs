using UnityEngine;

public class AutoNext : MonoBehaviour
{
    [Header("Dialogue Animation Settings")]
    public float typingDelay = 5f; // Delay before starting the typing effect
    public DialogueAnimation dialogueAnimation; // Reference to the DialogueAnimation script
    public string dialogueText; // The dialogue text for this page

    private void OnEnable()
    {
        // Automatically trigger the typing effect when this object is enabled
        Invoke(nameof(StartDialogueAnimation), typingDelay);
    }

    private void StartDialogueAnimation()
    {
        if (dialogueAnimation != null)
        {
            // Set the dialogue text and start the typing animation
            dialogueAnimation.SetDialogue(dialogueText);
            dialogueAnimation.StartTyping();
        }
        else
        {
            Debug.LogWarning("DialogueAnimation reference is not set in DialogueController.");
        }
    }
}
