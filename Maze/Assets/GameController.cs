using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{

    public static int trial = 1;
    public static int enterOldRoom;
    public static int enterEmptyRoom;
    public static int correct;
    public static int wrongColor;
    public static int wrongAll;
    public static float timeTravel;
    public static float distanceTravel;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Debug.Log("Trial: " + trial);

        enterEmptyRoom = 0;
        enterOldRoom = 0;
        correct = 0;
        wrongColor = 0;
        wrongAll = 0;
        distanceTravel = 0;
        timeTravel = 0;
    }
}
