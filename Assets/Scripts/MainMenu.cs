using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Reference to the confirmation pop-up
    public GameObject confirmationPopup;

    // Load the Case Review/Role Selection Screen
    public void BtnStart()
    {
        SceneManager.LoadScene("CaseReview_RoleSelectionScreen");
    }

    // Load the Tutorial Screen
    public void BtnTutorial()
    {
        SceneManager.LoadScene("TutorialScreen");
    }

    // Load the About Screen
    public void BtnAbout()
    {
        SceneManager.LoadScene("AboutScreen");
    }

    // Show the confirmation pop-up
    public void BtnQuit()
    {
        if (confirmationPopup != null)
        {
            confirmationPopup.SetActive(true); // Display the pop-up
        }
    }

    // Quit the game when "Yes" is clicked
    public void ConfirmQuit()
    {
        Application.Quit();
        Debug.Log("Game is exiting..."); // Log for editor testing
    }

    // Close the confirmation pop-up when "No" or Exit button is clicked
    public void ClosePopup()
    {
        if (confirmationPopup != null)
        {
            confirmationPopup.SetActive(false); // Hide the pop-up
        }
    }
}
