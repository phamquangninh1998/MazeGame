using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

[System.Serializable]
public class GameData
{
    public int enterEmptyRoom;
    public int enterOldRoom;
    public int ballToRightRoom;
    public int ballToWrongColorRoom;
    public int ballToEmptyRoom;
}