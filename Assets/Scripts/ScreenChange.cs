using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChange : MonoBehaviour
{
    [Header("Screens")]
    public GameObject chooseScreen;
    public GameObject inputScreen;
    public GameObject planScreen;
    public GameObject trainScreen;
    //public GameObject fifthScreen;

    private string saveScreen;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Screen"))
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
    private void CloseAll()
    {
        chooseScreen.SetActive(false);
        inputScreen.SetActive(false);
        planScreen.SetActive(false);
        //trainScreen.SetActive(false);
    }
}
