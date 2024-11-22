using UnityEngine;
using UnityEngine.UI;
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
        }

        // Add listener to the Present button
        presentButton.onClick.AddListener(PresentEvidence);
    }

    void SelectEvidence(int index)
    {
        // Reset all button colors to default (white)
        foreach (var button in evidenceButtons)
        {
            // Reset to default color (white)
            button.image.color = Color.white;
        }

        // Set the selected button color to transparent black
        Button selectedButton = evidenceButtons[index];
        selectedButton.image.color = new Color(0, 0, 0, 0.5f); // Transparent black (50% opacity)

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
