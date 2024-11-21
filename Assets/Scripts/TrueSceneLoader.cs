using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    public void BtnDayOne()
    {
        SceneManager.LoadScene("Pros_Day1Trial");
    }
    public void BtnDayTwo()
    {
        SceneManager.LoadScene("Pros_Day2Trial");
    }
    public void BtnInvestigation()
    {
        SceneManager.LoadScene("SpotTheDifferenceScreen");
    }

}