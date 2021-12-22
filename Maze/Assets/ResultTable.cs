using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTable : MonoBehaviour
{
    public void Show()
    {
        for (int i = 0; i < 5; i++)
        {
            Transform trial = transform.GetChild(i + 1);
            trial.GetChild(0).GetChild(1).GetComponent<Text>().text = "" + (i + 1);
            trial.GetChild(1).GetChild(1).GetComponent<Text>().text = "" + PlayerPrefs.GetInt("enterOldRoom" + (i + 1));
            trial.GetChild(2).GetChild(1).GetComponent<Text>().text = "" + PlayerPrefs.GetInt("enterEmptyRoom" + (i + 1));
            trial.GetChild(3).GetChild(1).GetComponent<Text>().text = "" + PlayerPrefs.GetInt("correct" + (i + 1));
            trial.GetChild(4).GetChild(1).GetComponent<Text>().text = "" + PlayerPrefs.GetInt("wrongColor" + (i + 1));
            trial.GetChild(5).GetChild(1).GetComponent<Text>().text = "" + PlayerPrefs.GetInt("wrongAll" + (i + 1));
            trial.GetChild(6).GetChild(1).GetComponent<Text>().text = "" + PlayerPrefs.GetFloat("timeTravel" + (i + 1));
            trial.GetChild(7).GetChild(1).GetComponent<Text>().text = "" + PlayerPrefs.GetFloat("distanceTravel" + (i + 1));

        }
    }
    private void OnEnable()
    {
        Show();
    }
}
