using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ResultTable : MonoBehaviour
{
    string fileName;
    private void Awake()
    {
        fileName = Application.dataPath + "/data.csv";
    }
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
        WriteToCSV();
    }

    public void WriteToCSV()
    {

        TextWriter tw = new StreamWriter(fileName, true);
        tw.WriteLine(" Entered Visited Rooms,Entered Empty Rooms,Balls Correctly Replaced,Balls Misplaced by Colour,Balls Misplaced, Time Taken, Distance Covered");
        tw.Close();

        for (int i = 0; i < 5; i++)
        {
            Transform trial = transform.GetChild(i + 1);
            int enterOldRoom = PlayerPrefs.GetInt("enterOldRoom" + (i + 1));
            int enterEmptyRoom = PlayerPrefs.GetInt("enterEmptyRoom" + (i + 1));
            int correct = PlayerPrefs.GetInt("correct" + (i + 1));
            int wrongColor = PlayerPrefs.GetInt("wrongColor" + (i + 1));
            int wrongAll = PlayerPrefs.GetInt("wrongAll" + (i + 1));
            float timeTravel = PlayerPrefs.GetFloat("timeTravel" + (i + 1));
            float distanceTravel = PlayerPrefs.GetFloat("distanceTravel" + (i + 1));

            tw = new StreamWriter(fileName, true);
            tw.WriteLine(enterOldRoom + "," + enterEmptyRoom + "," + correct + "," + wrongColor + "," + wrongAll + "," + timeTravel + "," + distanceTravel);
            tw.Close();
        }
    }
}
