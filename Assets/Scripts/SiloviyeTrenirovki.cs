using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiloviyeTrenirovki : MonoBehaviour
{
    [Header("Trains")]
    [SerializeField] private int[] easyTrain = new int[4];
    [SerializeField] private int[] mediumTrain = new int[4];
    [SerializeField] private int[] hardTrain = new int[4];
    [Header("Text")]
    public Text easyTrainText;
    public Text mediumTrainText;
    public Text hardTrainText;
    [Header("Screen")]
    public GameObject mainScreen;
    public GameObject breakScreen;
    public GameObject easyTrainScreen;
    public GameObject mediumTrainScreen;
    public GameObject hardTrainScreen;

    private int num = 0;

    private void Update()
    {
        if (num == 4)
        {
            ToMainScreen();
            CloseBreakScreen();
            num = 0;
        }
        easyTrainText.text = easyTrain[num].ToString();
        mediumTrainText.text = mediumTrain[num].ToString();
        hardTrainText.text = hardTrain[num].ToString();
    }
    public void StartEasyTrain()
    {
        num = 0;
        easyTrainScreen.SetActive(true);
        mediumTrainScreen.SetActive(false);
        hardTrainScreen.SetActive(false);
        mainScreen.SetActive(false);
    }
    public void StartMediumTrain()
    {
        num = 0;
        easyTrainScreen.SetActive(false);
        mediumTrainScreen.SetActive(true);
        hardTrainScreen.SetActive(false);
        mainScreen.SetActive(false);
    }
    public void StartHardTrain()
    {
        num = 0;
        easyTrainScreen.SetActive(false);
        mediumTrainScreen.SetActive(false);
        hardTrainScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
    public void ToMainScreen()
    {
        mainScreen.SetActive(true);
        easyTrainScreen.SetActive(false);
        mediumTrainScreen.SetActive(false);
        hardTrainScreen.SetActive(false);
    }
    public void BreakScreen()
    {
        breakScreen.SetActive(true);
    }
    public void Next()
    {
        num = num + 1;
        BreakScreen();
    }
    public void CloseBreakScreen()
    {
        breakScreen.SetActive(false);
    }
}
