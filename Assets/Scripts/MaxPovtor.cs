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

    public GameObject donePlan;

    private void Start()
    {
        screenChange = GetComponent<ScreenChange>();
        //���� ���� ������������ ���-�� ����������, �� ���������� ����
        if (PlayerPrefs.HasKey("MaxPovtor"))
        {
            maxPovtor = PlayerPrefs.GetInt("MaxPovtor");
            povtorText.text = "���� ������������ ���������� ������������: " + maxPovtor.ToString();

            //��������� ������ ������������� ������������
            FillArray(firstPlan, maxPovtor);
            FillArray(secondPlan, maxPovtor);
            FillArray(thirdPlan, maxPovtor);

            //������ ����
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
        //�������� ��������� ������������
        if(PlayerPrefs.HasKey("FirstTrain"))
            DoneFirstTrain();
        if (PlayerPrefs.HasKey("SecondTrain"))
            DoneSecondTrain();
        if(PlayerPrefs.HasKey("ThirdTrain"))
            DoneThirdTrain();

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
        //�������� ����� � ����������
        firstTrainPlanText.text = firstPlanText.text;
        secondTrainPlanText.text = secondPlanText.text;
        thirdTrainPlanText.text = thirdPlanText.text;

        firstTrain.text = firstPlan[el].ToString();
        secondTrain.text = secondPlan[el].ToString();
        thirdTrain.text = thirdPlan[el].ToString();

        //����� 5 ����� ���������� ������ ������� ����������� �����
        if(el == 4)
        {
            firstDoneTrain.SetActive(true);
            secondDoneTrain.SetActive(true);
            thirdDoneTrain.SetActive(true);
        }
    }
    
    //������ ������������� ���-�� ����������
    public void WriteMax()
    {
        maxPovtor = int.Parse(inputField.text);
        Debug.Log(maxPovtor);
    }
    public void SaveMax()
    {
        if (maxPovtor != 0)
        {
            //��������� ���������� � ����� �����
            PlayerPrefs.SetInt("MaxPovtor", maxPovtor);
            povtorText.text = "���� ������������ ���������� ������������: " + maxPovtor.ToString();

            //��������� ������ ������������� ������������
            FillArray(firstPlan, maxPovtor);
            FillArray(secondPlan, maxPovtor);
            FillArray(thirdPlan, maxPovtor);
            
            //���������� ���� ������ 4, ���� �����������. ������ ���� �������
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

            //����� � �������
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
            Debug.Log("������: 0 ������������ ����������");
        else
            Debug.Log("Error");
    }

    //��������� ������ ����� ��� ��� ��������� ����
    private void FillArray(int[] arr, int value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }
    }

    //������ � 1 �� 3 ����
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
        //������ ���� ���� ������ 4 ����������
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
    
    //���������� ���� �� �������� � ���
    private void WritePlan()
    {
        //���������� ������ � ���� ����������
        firstPlanText.text = firstPlan[0] + "    " + firstPlan[1] + "    " + firstPlan[2] + "    " + firstPlan[3] + "    " + firstPlan[4];
        secondPlanText.text = secondPlan[0] + "    " + secondPlan[1] + "    " + secondPlan[2] + "    " + secondPlan[3] + "    " + secondPlan[4];
        thirdPlanText.text = thirdPlan[0] + "    " + thirdPlan[1] + "    " + thirdPlan[2] + "    " + thirdPlan[3] + "    " + thirdPlan[4];
    }

    public void Next()
    {
        //��������� ������ 
        el = el + 1;
        BreakScreen();
        Debug.Log(el);
    }
    
    private void BreakScreen()
    {
        //������� �������
        breakScreen.SetActive(true);
    }

    public void CloseBreakScreen()
    {
        //������� �������
        breakScreen.SetActive(false);
    }

    //���������� 1-3 ����������
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
        //��������� 1 �����
        el = 0;
        firstTrainScreen.SetActive(false);
        firstButton.SetActive(false);
        secondButton.SetActive(true);
        firstDone.SetActive(true);
        PlayerPrefs.SetString("FirstTrain", "Done");

        CloseDoneButtons();
    }
    public void DoneSecondTrain()
    {
        //��������� 2 �����
        el = 0;
        secondTrainScreen.SetActive(false);
        secondButton.SetActive(false);
        thirdButton.SetActive(true);
        secondDone.SetActive(true);
        PlayerPrefs.SetString("SecondTrain", "Done");

        CloseDoneButtons();
    }
    public void DoneThirdTrain()
    {
        //��������� 3 �����
        el = 0;
        thirdTrainScreen.SetActive(false);
        thirdButton.SetActive(false);
        donePlan.SetActive(true);
        thirdDone.SetActive(true);
        PlayerPrefs.SetString("ThirdTrain", "Done");

        CloseDoneButtons();
    }
    public void DonePlan()
    {
        //����� �����
        //maxPovtor += 1;
        PlayerPrefs.SetInt("MaxPovtor", maxPovtor);
        PlayerPrefs.DeleteKey("FirstTrain");
        PlayerPrefs.DeleteKey("SecondTrain");
        PlayerPrefs.DeleteKey("ThirdTrain");

        firstButton.SetActive(true);
        secondButton.SetActive(false);
        thirdButton.SetActive(false);

        UnActiveDoneMarks();

        PlayerPrefs.SetString("Screen", "Input");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CloseDoneButtons()
    {
        //������������ ��� ������ ���������
        firstDoneTrain.SetActive(false);
        secondDoneTrain.SetActive(false);
        thirdDoneTrain.SetActive(false);
    }

    //��������� ���������� ����������
    private void UnActiveDoneMarks()
    {
        firstDone.SetActive(false);
        secondDone.SetActive(false);
        thirdDone.SetActive(false);
    }
    
    //���������� �� ����� � ����� ����������
    public void BackToPlan()
    {
        el = 0;
        firstTrainScreen.SetActive(false);
        secondTrainScreen.SetActive(false);
        thirdTrainScreen.SetActive(false);
    }
}
