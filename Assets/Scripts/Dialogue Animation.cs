using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMeshPro namespace
using System.Collections;

public class DialogueAnimation : MonoBehaviour
{
    public Text dialogueText; // Reference to the Text UI component (for regular Unity UI text)
    public TextMeshProUGUI dialogueTextTMP; // Reference to the TextMeshProUGUI component (for TextMesh Pro text)
    public float typingSpeed = 0.1f; // Typing speed (adjustable in the Inspector)
    private string dialogueLine; // Holds the dialogue text to be typed out

    // Set the dialogue text dynamically when a new page is shown
    public void SetDialogue(string newDialogue)
    {
        dialogueLine = newDialogue;

        // Clear existing text in both components
        if (dialogueText != null)
            dialogueText.text = "";

        if (dialogueTextTMP != null)
            dialogueTextTMP.text = "";
    }

    // Coroutine for the typing effect
    public void StartTyping()
    {
        StartCoroutine(TypeDialogue());
    }

    private IEnumerator TypeDialogue()
    {
        // Ensure text is cleared before starting typing
        if (dialogueText != null)
            dialogueText.text = "";

        if (dialogueTextTMP != null)
            dialogueTextTMP.text = "";

        Debug.Log("TypeDialogue coroutine started.");
        Debug.Log("Typing this dialogue line: " + dialogueLine);

        // Check if we are using TextMeshPro or regular Text
        if (dialogueText != null)
        {
            // Regular Text component (UI Text)
            foreach (char letter in dialogueLine)
            {
                dialogueText.text += letter;
                Debug.Log("Current text displayed: " + dialogueText.text);
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        else if (dialogueTextTMP != null)
        {
            // TextMeshPro component
            foreach (char letter in dialogueLine)
            {
                dialogueTextTMP.text += letter;
                Debug.Log("Current text displayed: " + dialogueTextTMP.text);
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}
