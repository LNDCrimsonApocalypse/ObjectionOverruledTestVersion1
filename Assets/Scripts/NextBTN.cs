using UnityEngine;
using UnityEngine.EventSystems;

public class NextBtn : MonoBehaviour, IPointerClickHandler
{
    public GameObject currentPage;    // Reference to the current page (Page 1)
    public GameObject nextPage;       // Reference to the next page (Page 2)
    public DialogueAnimation dialogueAnimation;  // Reference to the DialogueAnimation script (Page 2)

    public string dialogueForNextPage;  // The dialogue text for Page 2

    // This method is triggered when the NextButton is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // Hide the current page (Page 1)
        currentPage.SetActive(false);

        // Show the next page (Page 2)
        nextPage.SetActive(true);

        // Set the dialogue text for Page 2 dynamically
        dialogueAnimation.SetDialogue(dialogueForNextPage);

        // Start the typing effect (the text typing animation on Page 2)
        dialogueAnimation.StartTyping();
    }
}
