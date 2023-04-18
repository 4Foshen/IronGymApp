using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaxPovtor : MonoBehaviour
{
    public int maxPovtor = 0;
    private ScreenChange screenChange;
    [SerializeField] private InputField inputField;
    [SerializeField] private Text povtorText;

    [Header("PlanText")]
    public Text firstPlanText;
    public Text secondPlanText;
    public Text thirdPlanText;

    private int[] firstPlan = new int[5];
    private int[] secondPlan = new int[5];
    private int[] thirdPlan = new int[5];

    private int el = 0;


    [Header("TrainText")]
    public Text firstTrainPlanText;
    public Text secondTrainPlanText;
    public Text thirdTrainPlanText;

    public Text firstTrain;
    public Text secondTrain;
    public Text thirdTrain;

    [Header("TrainScreens")]
    public GameObject firstTrainScreen;
    public GameObject secondTrainScreen;
    public GameObject thirdTrainScreen;
    public GameObject breakScreen;

    [Header("Buttons")]
    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;

    public GameObject firstDone;
    public GameObject secondDone;
    public GameObject thirdDone;

    public GameObject firstDoneTrain;
    public GameObject secondDoneTrain;
    public GameObject thirdDoneTrain;

    private void Start()
    {
        screenChange = GetComponent<ScreenChange>();
        if (PlayerPrefs.HasKey("MaxPovtor"))
        {
            maxPovtor = PlayerPrefs.GetInt("MaxPovtor");
            povtorText.text = "Ваше максимальное количество подтягиваний: " + maxPovtor.ToString();

            //Заполняет массив максимальными повторениями
            FillArray(firstPlan, maxPovtor);
            FillArray(secondPlan, maxPovtor);
            FillArray(thirdPlan, maxPovtor);

            //Строит план
            if (maxPovtor < 4)
            {
                BuildPlanMin();
                WritePlan();
            }
            else
            {
                BuildPlan();
                WritePlan();
            }
        }
        Debug.Log(maxPovtor);
        foreach (int el in firstPlan)
        {
            Debug.Log(el);
        }
        foreach (int el in secondPlan)
        {
            Debug.Log(el);
        }
        foreach (int el in thirdPlan)
        {
            Debug.Log(el);
        }
    }
    private void Update()
    {
        //Меняется текст в тренировке
        firstTrainPlanText.text = firstPlanText.text;
        secondTrainPlanText.text = secondPlanText.text;
        thirdTrainPlanText.text = thirdPlanText.text;

        firstTrain.text = firstPlan[el].ToString();
        secondTrain.text = secondPlan[el].ToString();
        thirdTrain.text = thirdPlan[el].ToString();

        //Когда 5 треня появляется кнопка которая заканчивает треню
        if(el == 4)
        {
            firstDoneTrain.SetActive(true);
            secondDoneTrain.SetActive(true);
            thirdDoneTrain.SetActive(true);
        }
        
    }
    public void WriteMax()
    {
        maxPovtor = int.Parse(inputField.text);
        Debug.Log(maxPovtor);
    }
    public void SaveMax()
    {
        if (maxPovtor != 0)
        {
            PlayerPrefs.SetInt("MaxPovtor", maxPovtor);
            povtorText.text = "Ваше максимальное количество подтягиваний: " + maxPovtor.ToString();

            //Заполняет массив максимальными повторениями
            FillArray(firstPlan, maxPovtor);
            FillArray(secondPlan, maxPovtor);
            FillArray(thirdPlan, maxPovtor);
            
            //СтроитПлан
            if(maxPovtor < 4)
            {
                BuildPlanMin();
                WritePlan();
            }
            else
            {
                BuildPlan();
                WritePlan();
            }
            screenChange.ToPlanScreen();

            //Вывод в консоль
            foreach (int el in firstPlan)
            {
                Debug.Log(el);
            }
            foreach (int el in secondPlan)
            {
                Debug.Log(el);
            }
            foreach (int el in thirdPlan)
            {
                Debug.Log(el);
            }

        }
        else if (maxPovtor == 0)
            Debug.Log("Ошибка: 0 максимальных повторений");
        else
            Debug.Log("Error");
    }

    private void FillArray(int[] arr, int value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }
    }
    private void BuildPlan()
    {
        BuildFirst();
        BuildSecond();
        BuildThird();
    }

    private void BuildFirst()
    {
        firstPlan[0] -= 2;
        firstPlan[1] -= 3;
        firstPlan[2] -= 3;
        firstPlan[3] -= 3;
        firstPlan[4] -= 3;
    }
    private void BuildSecond()
    {
        secondPlan[0] -= 2;
        secondPlan[1] -= 2;
        secondPlan[2] -= 3;
        secondPlan[3] -= 3;
        secondPlan[4] -= 3;
    }
    private void BuildThird()
    {
        thirdPlan[0] -= 1;
        thirdPlan[1] -= 2;
        thirdPlan[2] -= 2;
        thirdPlan[3] -= 3;
        thirdPlan[4] -= 3;
    }

    private void BuildPlanMin()
    {
        for(int i = 0; i < firstPlan.Length; i++)
        {
            firstPlan[i] = 1;
        }
        for(int i = 0; i < secondPlan.Length; i++)
        {
            secondPlan[i] = 1;
        }
        for(int i = 0; i < thirdPlan.Length; i++)
        {
            thirdPlan[i] = 1;
        }
    }
    
    //Записывает план из массивов в дни
    private void WritePlan()
    {
        firstPlanText.text = firstPlan[0] + "    " + firstPlan[1] + "    " + firstPlan[2] + "    " + firstPlan[3] + "    " + firstPlan[4];
        secondPlanText.text = secondPlan[0] + "    " + secondPlan[1] + "    " + secondPlan[2] + "    " + secondPlan[3] + "    " + secondPlan[4];
        thirdPlanText.text = thirdPlan[0] + "    " + thirdPlan[1] + "    " + thirdPlan[2] + "    " + thirdPlan[3] + "    " + thirdPlan[4];
    }

    public void Next()
    {
        //Следующий подход
        el = el + 1;
        BreakScreen();
        Debug.Log(el);
    }
    
    private void BreakScreen()
    {
        //Открыть перерыв
        breakScreen.SetActive(true);
    }

    public void CloseBreakScreen()
    {
        //Закрыть перерыв
        breakScreen.SetActive(false);
    }

    public void StartFirstTrain()
    {
        firstTrainScreen.SetActive(true);
    }
    public void StartSecondTrain()
    {
        secondTrainScreen.SetActive(true);
    }
    public void StartThirdTrain()
    {
        thirdTrainScreen.SetActive(true);
    }

    public void DoneFirstTrain()
    {
        //Закончить треню
        el = 0;
        firstTrainScreen.SetActive(false);
        screenChange.planScreen.SetActive(true);
        PlayerPrefs.SetString("FirstTrain", "Done");

        CloseDoneButtons();
    }
    public void DoneSecondTrain()
    {
        //Закончить треню
        el = 0;
        firstTrainScreen.SetActive(false);
        screenChange.planScreen.SetActive(true);
        PlayerPrefs.SetString("SecondTrain", "Done");

        CloseDoneButtons();
    }
    public void DoneThirdTrain()
    {
        //Закончить треню
        el = 0;
        firstTrainScreen.SetActive(false);
        screenChange.planScreen.SetActive(true);
        PlayerPrefs.SetString("ThirdTrain", "Done");

        CloseDoneButtons();
    }
    public void DonePlan()
    {
        maxPovtor += 1;
        PlayerPrefs.DeleteKey("FirstTrain");
        PlayerPrefs.DeleteKey("SecondTrain");
        PlayerPrefs.DeleteKey("ThirdTrain");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CloseDoneButtons()
    {
        firstDoneTrain.SetActive(false);
        secondDoneTrain.SetActive(false);
        thirdDoneTrain.SetActive(false);
    }
}
