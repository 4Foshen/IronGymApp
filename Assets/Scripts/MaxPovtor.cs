using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class MaxPovtor : MonoBehaviour
{
    public int maxPovtor = 0;
    private ScreenChange screenChange;
    [SerializeField] private InputField inputField;
    [SerializeField] private Text povtorText;

    [Header("PlanText")]
    [SerializeField] private Text firstPlanText;
    [SerializeField] private Text secondPlanText;
    [SerializeField] private Text thirdPlanText;

    private int[] firstPlan = new int[5];
    private int[] secondPlan = new int[5];
    private int[] thirdPlan = new int[5];

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
}
