using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EvidenceSelector : MonoBehaviour
{
    public Button[] evidenceButtons; // Buttons for evidence
    public Button presentButton;

    public GameObject mainPage; // Main page (previously main canvas)
    public GameObject evidence1Page; // Evidence 1 page
    public GameObject evidence2Page; // Evidence 2 page
    public GameObject evidence3Page; // Evidence 3 page

    private int selectedEvidence = -1; // No selection initially

    void Start()
    {
        // Add listeners to each evidence button
        for (int i = 0; i < evidenceButtons.Length; i++)
        {
            int index = i; // Capture the index for closure
            evidenceButtons[i].onClick.AddListener(() => SelectEvidence(index));

            // Add hover events
            AddHoverEffect(evidenceButtons[i], index);
        }

        // Add listener to the Present button
        presentButton.onClick.AddListener(PresentEvidence);

        // Ensure all overlays are initially transparent
        foreach (var button in evidenceButtons)
        {
            Transform overlay = button.transform.Find("Overlay");
            if (overlay != null)
            {
                overlay.GetComponent<Image>().color = new Color(0, 0, 0, 0); // Fully transparent
            }
        }
    }

    void AddHoverEffect(Button button, int index)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        // Add pointer enter event (hover start)
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((_) => OnHoverEnter(index));
        trigger.triggers.Add(pointerEnter);

        // Add pointer exit event (hover end)
        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((_) => OnHoverExit(index));
        trigger.triggers.Add(pointerExit);
    }

    void OnHoverEnter(int index)
    {
        // Show hover effect (light transparent overlay)
        Transform overlay = evidenceButtons[index].transform.Find("Overlay");
        if (overlay != null && selectedEvidence != index)
        {
            overlay.GetComponent<Image>().color = new Color(0, 0, 0, 0.2f); // Light transparent black
        }
    }

    void OnHoverExit(int index)
    {
        // Remove hover effect
        Transform overlay = evidenceButtons[index].transform.Find("Overlay");
        if (overlay != null && selectedEvidence != index)
        {
            overlay.GetComponent<Image>().color = new Color(0, 0, 0, 0); // Fully transparent
        }
    }

    void SelectEvidence(int index)
    {
        // Reset all overlay colors to fully transparent
        foreach (var button in evidenceButtons)
        {
            Transform overlay = button.transform.Find("Overlay");
            if (overlay != null)
            {
                overlay.GetComponent<Image>().color = new Color(0, 0, 0, 0); // Fully transparent
            }
        }

        // Set the selected overlay color to transparent black
        Transform selectedOverlay = evidenceButtons[index].transform.Find("Overlay");
        if (selectedOverlay != null)
        {
            selectedOverlay.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f); // Transparent black (50% opacity)
        }

        selectedEvidence = index; // Store the selected evidence
    }

    void PresentEvidence()
    {
        if (selectedEvidence == -1)
        {
            Debug.Log("No evidence selected!");
            return;
        }

        // Handle transitions based on evidence selected
        switch (selectedEvidence)
        {
            case 0: // Evidence 1: Load Scene for Evidence 1
                SceneManager.LoadScene("Scene_Evidence1");
                break;

            case 1: // Evidence 2: Load Scene for Evidence 2
                SceneManager.LoadScene("Scene_Evidence2");
                break;

            case 2: // Evidence 3: Stay in current scene, show relevant page
                mainPage.SetActive(false);
                evidence3Page.SetActive(true);
                break;

            default:
                Debug.LogError("Invalid evidence selection!");
                break;
        }
    }
}
