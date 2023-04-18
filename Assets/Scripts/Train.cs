using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : MonoBehaviour
{
    public MaxPovtor mxPovtor;

    [Header("UI")]
    public Text firstTrainPlanText;
    public Text secondTrainPlanText;
    public Text thirdTrainPlanText;

    public Text firstTrain;
    public Text secondTrain;
    public Text thirdTrain;

    public GameObject breakScreen;

    private int el;

    

    private void OnEnable()
    {
        //firstPlan = mxPovtor.firstPlan[];

        //firstTrainPlanText.text = mxPovtor.firstPlanText.text;
        //secondTrainPlanText.text = mxPovtor.secondPlanText.text;
        //thirdTrainPlanText.text = mxPovtor.thirdPlanText.text;


        //firstTrain.text = mxPovtor.firstPlan[0];
    }

    private void Next()
    {

    }
}
