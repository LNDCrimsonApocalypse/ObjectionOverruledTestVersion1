using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void BtnStart()
    {
        SceneManager.LoadScene("CaseReview_RoleSelectionScreen");
    }

    /*    public void BtnRestart()
        {
            SceneManager.LoadScene("MainMenu");
        }*/
    public void BtnOption()
    {
        SceneManager.LoadScene("SettingsScreen");
    }
    public void BtnTutorial()
    {
        SceneManager.LoadScene("TutorialScreen");
    }

    public void BtnAbout()
    {
        SceneManager.LoadScene("AboutScreen");
    }

    public void BtnQuit()
    {
        Application.Quit();
    }

}
