using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void Btn()
    {
        SceneManager.LoadScene("StartAgain");
    }

    public void BtnRestart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void BtnSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

}