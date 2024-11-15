using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueAnimation : MonoBehaviour
{
    public Text dialogueText; // Reference to the Text UI component for displaying the dialogue
    public float typingSpeed = 0.1f; // Typing speed (adjustable in the Inspector)
    private string dialogueLine; // Holds the dialogue text to be typed out

    // Set the dialogue text dynamically when a new page is shown
    public void SetDialogue(string newDialogue)
    {
        dialogueLine = newDialogue;
        dialogueText.text = "";  // Clear any existing text
    }

    // Coroutine for the typing effect
    public void StartTyping()
    {
        StartCoroutine(TypeDialogue());
    }

    private IEnumerator TypeDialogue()
    {
        dialogueText.text = "";  // Ensure text is cleared before starting typing
        Debug.Log("TypeDialogue coroutine started.");
        Debug.Log("Typing this dialogue line: " + dialogueLine);

        foreach (char letter in dialogueLine)
        {
            dialogueText.text += letter;
            Debug.Log("Current text displayed: " + dialogueText.text);
            yield return new WaitForSeconds(typingSpeed);
        }
    }


}
