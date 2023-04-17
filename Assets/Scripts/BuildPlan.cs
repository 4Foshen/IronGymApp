using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPlan : MonoBehaviour
{
    [Header("PlanText")]
    [SerializeField] private Text firstPlanText;
    [SerializeField] private Text secondPlanText;
    [SerializeField] private Text thirdPlanText;
    [Header("Script")]
    private MaxPovtor mxPovtor;

    private int[] firstPlan = new int[4];
    private int[] secondPlan = new int[4];
    private int[] thirdPlan = new int[4];
    private void Start()
    {
        mxPovtor= GetComponent<MaxPovtor>();
        FillArray(firstPlan, mxPovtor.maxPovtor);
        Debug.Log(firstPlan);
    }

    private void FillArray(int[] arr, int value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }
    }
}
