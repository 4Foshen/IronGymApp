using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenChange : MonoBehaviour
{
    [Header("Screens")]
    public GameObject chooseScreen;
    public GameObject inputScreen;
    public GameObject planScreen;
    //public GameObject fifthScreen;

    private string saveScreen;
    private void Start()
    {
        var scene = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.HasKey("Screen") && scene == 0)
        {
            saveScreen = PlayerPrefs.GetString("Screen");
            switch (saveScreen)
            {
                case "Choose":
                    ToChooseScreen();
                    break;
                case "Input":
                    ToInputScreen(); 
                    break;
                case "Plan":
                    ToPlanScreen();
                    break;
                default:
                    ToChooseScreen();
                    break;
            }
        }
    }
    public void ToChooseScreen()
    {
        CloseAll();
        chooseScreen.SetActive(true);
        PlayerPrefs.SetString("Screen", "Choose");
    }
    public void ToInputScreen()
    {
        CloseAll();
        inputScreen.SetActive(true);
        PlayerPrefs.SetString("Screen", "Input");
    }
    public void ToPlanScreen()
    {
        CloseAll();
        planScreen.SetActive(true);
        PlayerPrefs.SetString("Screen", "Plan");
    }
    public void ToTrainers()
    {
        SceneManager.LoadScene("Trainers Scene");
    }
    public void ToMain()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void ToZhim()
    {
        SceneManager.LoadScene("Zhim Scene");
    }
    public void ToBiceps()
    {
        SceneManager.LoadScene("Biceps Scene");
    }
    public void ToYoga()
    {
        SceneManager.LoadScene("Yoga Scene");
    }
    public void ToPilates()
    {
        SceneManager.LoadScene("Pilates Scene");
    }
    private void CloseAll()
    {
        chooseScreen.SetActive(false);
        inputScreen.SetActive(false);
        planScreen.SetActive(false);
        //trainScreen.SetActive(false);
    }
}
