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
                case "Main":
                    break;
                case "Choose":
                    ToChooseScreen();
                    break;
                case "Input":
                    ToInputScreen(); 
                    break;
                case "Plan":
                    ToPlanScreen();
                    break;
                case "Zhim":
                    ToZhim();
                    break;
                case "Biceps":
                    ToBiceps();
                    break;
                case "Yoga":
                    ToYoga();
                    break;
                case "Pilates":
                    ToPilates();
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
        PlayerPrefs.SetString("Screen", "Main");
    }
    public void ToZhim()
    {
        SceneManager.LoadScene("Zhim Scene");
        PlayerPrefs.SetString("Screen", "Zhim");
    }
    public void ToBiceps()
    {
        SceneManager.LoadScene("Biceps Scene");
        PlayerPrefs.SetString("Screen", "Biceps");
    }
    public void ToYoga()
    {
        SceneManager.LoadScene("Yoga Scene");
        PlayerPrefs.SetString("Screen", "Yoga");
    }
    public void ToPilates()
    {
        SceneManager.LoadScene("Pilates Scene");
        PlayerPrefs.SetString("Screen", "Pilates");
    }
    private void CloseAll()
    {
        chooseScreen.SetActive(false);
        inputScreen.SetActive(false);
        planScreen.SetActive(false);
        //trainScreen.SetActive(false);
    }
}
