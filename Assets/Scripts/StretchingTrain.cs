using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchingTrain : MonoBehaviour
{
    public GameObject firstUprazhneniye;
    public GameObject secondUprazhneniye;
    public GameObject trainScreen;
    public GameObject breakScreen;

    private string train = "First";

    public void Next()
    {
        trainScreen.SetActive(false);
        breakScreen.SetActive(true);
        if(train == "First")
        {
            firstUprazhneniye.SetActive(false);
            secondUprazhneniye.SetActive(true);
            train = "Second";
        }
        else if(train == "Second")
        {
            firstUprazhneniye.SetActive(true);
            secondUprazhneniye.SetActive(false);
            train = "First";
        }
    }
    public void CloseBreakScreen()
    {
        breakScreen.SetActive(false);
        trainScreen.SetActive(true);
    }
}
